using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Framework.Models
{
    /// <summary>
    /// Project
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Project Id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        /// <summary>
        /// Project Name
        /// </summary>
        [JsonProperty(PropertyName ="projectname")]
        public string ProjectName { get; set; }
        /// <summary>
        /// Account Id
        /// </summary>
        [JsonProperty(PropertyName ="account")]
        public string AccountId { get; set; }
    }
}