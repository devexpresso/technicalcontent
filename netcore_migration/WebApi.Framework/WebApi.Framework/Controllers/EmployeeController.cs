using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Framework.Models;


namespace WebApi.Framework.Controllers
{
    /// <summary>
    /// Employee
    /// </summary>
    public class EmployeeController : ApiController
    {
        /// <summary>
        /// Get All Employees
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetAllEmployees")]
        public async Task<HttpResponseMessage> GetAllEmployees()
        {
            try
            {
                var employees = await DocumentDBRepository<Employee>.GetItemsAsync();
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Found,
                    Content = new StringContent(JsonConvert.SerializeObject(employees), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        /// <summary>
        /// Get All Billable Employees
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetAllBillableEmployees")]
        public async Task<HttpResponseMessage> GetAllBillableEmployees()
        {
            try
            {
                var employees = await DocumentDBRepository<Employee>.GetItemsAsync(d => d.Billable);
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Found,
                    Content = new StringContent(JsonConvert.SerializeObject(employees), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        /// <summary>
        /// Get an Employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("GetEmployee/{id}")]
        public async Task<HttpResponseMessage> GetEmployee(string id)
        {
            try
            {
                var employees = await DocumentDBRepository<Employee>.GetItemsAsync(d => d.Id == id);
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Found,
                    Content = new StringContent(JsonConvert.SerializeObject(employees), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        /// <summary>
        /// Add an Employee
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("AddEmployee")]
        public async Task<HttpResponseMessage> AddEmployee([System.Web.Mvc.Bind(Include = "Id,EmployeeId,FirstName,LastName,DateOfBirth,Department,ProjectId,Billable")] Employee emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await DocumentDBRepository<Employee>.CreateItemAsync(emp);

                    return new HttpResponseMessage(HttpStatusCode.Created);
                }
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        /// <summary>
        /// Update an Employee
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpPut]
        [ActionName("UpdateEmployee")]
        public async Task<HttpResponseMessage> UpdateEmployee([System.Web.Mvc.Bind(Include = "Id,EmployeeId,FirstName,LastName,DateOfBirth,Department,ProjectId,Billable")] Employee emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await DocumentDBRepository<Employee>.UpdateItemAsync(emp.Id, emp);

                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        /// <summary>
        /// Delete an Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ActionName("DeleteEmployee/{id}")]
        public async Task<HttpResponseMessage> DeleteEmployee(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);

                await DocumentDBRepository<Employee>.DeleteItemAsync(id);

                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }


    }
}
