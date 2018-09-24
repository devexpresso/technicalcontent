using System;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using EmployeeManagement.Api.Command.Employee;
using EmployeeManagement.Api.Query.Employee;
using EmployeeManagement.Api.Request;
using EmployeeManagement.Api.Request.Employee;
using EmployeeManagement.Model;
using EmployeeManagement.Provider.Interface;
using EmployeeManagement.Provider.Provider;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
    /// <summary>
    /// Employee 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfigurationProvider<Employee> _provider;
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="mediator"></param>
        public EmployeeController(IConfigurationProvider<Employee> provider, IMediator mediator)
        {
            _provider = provider;
            _mediator = mediator;
        }

        /// <summary>
        /// Get All Employees
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var response = await _mediator.Send(new GetAllEmployeesQuery());
                return StatusCode(response.ResponseStatusCode, response.Value);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Get all Billable employees
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetAllBillableEmployees")]
        public async Task<IActionResult> GetAllBillableEmployees()
        {
            try
            {
                var response = await _mediator.Send(new GetEmployeeByFilterQuery
                {
                    IsBillable = d => d.Billable
                });

                return StatusCode(response.ResponseStatusCode, response.Value);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Get an employee by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("GetEmployeeById/{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var response = await _mediator.Send(new GetEmployeeByIdQuery { EmployeeId = id });

                return StatusCode(response.ResponseStatusCode, response.Value);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Add an employee
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeCommand command)
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
        /// Update an employee
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [ActionName("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] ModifyEmployeeCommand command)
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
        /// Delete an employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ActionName("DeleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var response = await _mediator.Send(new DeleteEmployeeCommand { EmployeeId = id });

                return StatusCode(response.ResponseStatusCode, response.Value);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


    }
}