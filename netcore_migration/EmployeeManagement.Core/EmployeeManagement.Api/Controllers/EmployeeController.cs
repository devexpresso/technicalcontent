using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EmployeeManagement.Model;
using EmployeeManagement.Provider.Interface;
using EmployeeManagement.Provider.Provider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfigurationProvider<Employee> _provider;

        public EmployeeController(IConfigurationProvider<Employee> Provider)
        {
            _provider = Provider;
        }

        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var employees = await _provider.GetAll();
                return Ok(employees);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}