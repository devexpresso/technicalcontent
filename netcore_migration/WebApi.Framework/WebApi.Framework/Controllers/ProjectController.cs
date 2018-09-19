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
    /// Projects
    /// </summary>
    public class ProjectController : ApiController
    {
        /// <summary>
        /// Get All Projects
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetAllProjects")]
        public async Task<HttpResponseMessage> GetAllProjects()
        {
            try
            {
                var projects = await DocumentDBRepository<Project>.GetItemsAsync();
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Found,
                    Content = new StringContent(JsonConvert.SerializeObject(projects), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        /// <summary>
        /// Get Project by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("GetProject/{id}")]
        public async Task<HttpResponseMessage> GetProject(string id)
        {
            try
            {
                var project = await DocumentDBRepository<Project>.GetItemsAsync(d => d.Id == id);
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Found,
                    Content = new StringContent(JsonConvert.SerializeObject(project), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        /// <summary>
        /// Add Project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("AddProject")]
        public async Task<HttpResponseMessage> AddProject([System.Web.Mvc.Bind(Include = "Id,ProjectName,AccountId")] Project project)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await DocumentDBRepository<Project>.CreateItemAsync(project);

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
        /// Update a Project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPut]
        [ActionName("UpdateEmployee")]
        public async Task<HttpResponseMessage> UpdateProject([System.Web.Mvc.Bind(Include = "Id,ProjectName,AccountId")] Project project)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await DocumentDBRepository<Project>.UpdateItemAsync(project.Id, project);

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
        /// Delete Project
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ActionName("DeleteProject/{id}")]
        public async Task<HttpResponseMessage> DeleteProject(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);

                await DocumentDBRepository<Project>.DeleteItemAsync(id);

                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }
    }
}
