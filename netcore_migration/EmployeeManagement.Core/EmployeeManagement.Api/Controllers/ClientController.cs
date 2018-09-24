using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Api.Command.Client;
using EmployeeManagement.Api.Query.Client;
using EmployeeManagement.Model;
using EmployeeManagement.Provider.Interface;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
    /// <summary>
    /// Client
    /// </summary>
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IConfigurationProvider<Client> _provider;
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="mediator"></param>
        public ClientController(IConfigurationProvider<Client> provider, IMediator mediator)
        {
            _provider = provider;
            _mediator = mediator;
        }

        /// <summary>
        /// Get All Clients
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetAllClients")]
        public async Task<IActionResult> GetAllClients()
        {
            try
            {
                var response = await _mediator.Send(new GetAllClientsQuery());
                return StatusCode(response.ResponseStatusCode, response.Value);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Get a Client by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("GetClientById/{id}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            try
            {
                var response = await _mediator.Send(new GetClientByIdQuery { ClientId = id });

                return StatusCode(response.ResponseStatusCode, response.Value);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Add a Client
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("AddCient")]
        public async Task<IActionResult> AddCient([FromBody] AddClientCommand command)
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
        /// Update a client
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [ActionName("UpdateClient")]
        public async Task<IActionResult> UpdateClient([FromBody] ModifyClientCommand command)
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
        /// Delete a Client
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ActionName("DeleteClient/{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            try
            {
                var response = await _mediator.Send(new DeleteClientCommand { ClientId = id });

                return StatusCode(response.ResponseStatusCode, response.Value);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}