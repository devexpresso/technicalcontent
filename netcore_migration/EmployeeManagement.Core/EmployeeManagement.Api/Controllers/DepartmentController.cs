using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Api.Command.Department;
using EmployeeManagement.Api.Query.Department;
using EmployeeManagement.Model;
using EmployeeManagement.Provider.Interface;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
    /// <summary>
    /// Department
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfigurationProvider<Department> _provider;
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="mediator"></param>
        public DepartmentController(IConfigurationProvider<Department> provider, IMediator mediator)
        {
            _provider = provider;
            _mediator = mediator;
        }

        /// <summary>
        /// Get All Departments
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetAllDepartments")]
        public async Task<IActionResult> GetAllDepartments()
        {
            try
            {
                var response = await _mediator.Send(new GetAllDepartmentsQuery());
                return StatusCode(response.ResponseStatusCode, response.Value);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Get a Department by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("GetDepartmentById/{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            try
            {
                var response = await _mediator.Send(new GetDepartmentByIdQuery { DepartmentId = id });

                return StatusCode(response.ResponseStatusCode, response.Value);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Add a Department
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("AddDepartment")]
        public async Task<IActionResult> AddDepartment([FromBody] AddDepartmentCommand command)
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
        /// Update a Department
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [ActionName("UpdateDepartment")]
        public async Task<IActionResult> UpdateDepartment([FromBody] ModifyDepartmentCommand command)
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
        /// Delete a Department
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ActionName("DeleteDepartment/{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            try
            {
                var response = await _mediator.Send(new DeleteDepartmentCommand { DepartmentId = id });

                return StatusCode(response.ResponseStatusCode, response.Value);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}