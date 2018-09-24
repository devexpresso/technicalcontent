using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Api.Command.Project;
using EmployeeManagement.Api.Query.Project;
using EmployeeManagement.Model;
using EmployeeManagement.Provider.Interface;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
    /// <summary>
    /// Project
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IConfigurationProvider<Project> _provider;
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="mediator"></param>
        public ProjectController(IConfigurationProvider<Project> provider, IMediator mediator)
        {
            _provider = provider;
            _mediator = mediator;
        }

        /// <summary>
        /// Get All Projects
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetAllProjects")]
        public async Task<IActionResult> GetAllProjects()
        {
            try
            {
                var response = await _mediator.Send(new GetAllProjectsQuery());
                return StatusCode(response.ResponseStatusCode, response.Value);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Get a Project by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("GetProjectById/{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            try
            {
                var response = await _mediator.Send(new GetProjectByIdQuery { ProjectId = id });

                return StatusCode(response.ResponseStatusCode, response.Value);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Add a Project
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("AddProject")]
        public async Task<IActionResult> AddProject([FromBody] AddProjectCommand command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await _mediator.Send(command);
                    return StatusCode(response.ResponseStatusCode, response.Value);
                }
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Update a project
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [ActionName("UpdateProject")]
        public async Task<IActionResult> UpdateProject([FromBody] ModifyProjectCommand command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await _mediator.Send(command);

                    return StatusCode(response.ResponseStatusCode, response.Value);
                }
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Delete a project
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ActionName("DeleteProject/{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            try
            {
                var response = await _mediator.Send(new DeleteProjectCommand { ProjectId = id });

                return StatusCode(response.ResponseStatusCode, response.Value);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}