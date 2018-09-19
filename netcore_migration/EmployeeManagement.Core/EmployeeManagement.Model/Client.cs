using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Model
{
    /// <summary>
    /// Client model
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Client id
        /// </summary>
        [JsonProperty(PropertyName ="id")]
        public int ClientId { get; set; }
        /// <summary>
        /// Client name
        /// </summary>
        [JsonProperty(PropertyName ="name")]
        public string ClientName { get; set; }
        /// <summary>
        /// Client location
        /// </summary>
        [JsonProperty(PropertyName ="location")]
        public string ClientLocation { get; set; }
    }
}
