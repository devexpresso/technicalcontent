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
    /// Accounts
    /// </summary>
    public class AccountController : ApiController
    {
        /// <summary>
        /// Get All Accounts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetAllAccounts")]
        public async Task<HttpResponseMessage> GetAllAccounts()
        {
            try
            {
                var accounts = await DocumentDBRepository<Account>.GetItemsAsync();
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Found,
                    Content = new StringContent(JsonConvert.SerializeObject(accounts), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        /// <summary>
        /// Get Account by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("GetAccount/{id}")]
        public async Task<HttpResponseMessage> GetAccount(string id)
        {
            try
            {
                var account = await DocumentDBRepository<Account>.GetItemsAsync(d => d.AccountId == id);
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Found,
                    Content = new StringContent(JsonConvert.SerializeObject(account), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        /// <summary>
        /// Add Account
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("AddAccount")]
        public async Task<HttpResponseMessage> AddAccount([System.Web.Mvc.Bind(Include = "AccountId,AccountName")] Account account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await DocumentDBRepository<Account>.CreateItemAsync(account);

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
        /// Update an Account
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [HttpPut]
        [ActionName("UpdateAccount")]
        public async Task<HttpResponseMessage> UpdateAccount([System.Web.Mvc.Bind(Include = "AccountId,AccountName")] Account account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await DocumentDBRepository<Account>.UpdateItemAsync(account.AccountId, account);

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
        /// Delete Account
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ActionName("DeleteAccount/{id}")]
        public async Task<HttpResponseMessage> DeleteAccount(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);

                await DocumentDBRepository<Account>.DeleteItemAsync(id);

                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }
    }
}
