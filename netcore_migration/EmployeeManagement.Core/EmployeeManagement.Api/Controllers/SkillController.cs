using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Api.Command.Skill;
using EmployeeManagement.Api.Query.Skills;
using EmployeeManagement.Model;
using EmployeeManagement.Provider.Interface;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
    /// <summary>
    /// Skills
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly IConfigurationProvider<Skills> _provider;
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="mediator"></param>
        public SkillController(IConfigurationProvider<Skills> provider, IMediator mediator)
        {
            _provider = provider;
            _mediator = mediator;
        }

        /// <summary>
        /// Get All Skills
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetAllSkills")]
        public async Task<IActionResult> GetAllSkills()
        {
            try
            {
                var response = await _mediator.Send(new GetAllSkillsQuery());
                return StatusCode(response.ResponseStatusCode, response.Value);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Get a Skill by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("GetSkillById/{id}")]
        public async Task<IActionResult> GetSkillById(int id)
        {
            try
            {
                var response = await _mediator.Send(new GetSkillByIdQuery { SkillId = id });

                return StatusCode(response.ResponseStatusCode, response.Value);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Add a Skill
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("AddSkill")]
        public async Task<IActionResult> AddSkill([FromBody] AddSkillCommand command)
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
        /// Update a Skill
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [ActionName("UpdateSkill")]
        public async Task<IActionResult> UpdateSkill([FromBody] ModifySkillCommand command)
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
        /// Delete a Skill
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ActionName("DeleteSkill/{id}")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            try
            {
                var response = await _mediator.Send(new DeleteSkillCommand { SkillId = id });

                return StatusCode(response.ResponseStatusCode, response.Value);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}