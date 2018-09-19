using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Framework.Models
{
    /// <summary>
    /// Account Information
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Account Id
        /// </summary>
        [JsonProperty(PropertyName ="id")]
        public string AccountId { get; set; }
        /// <summary>
        /// Account Name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string AccountName { get; set; }
    }
}