using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Model
{
    public class Project
    {
        /// <summary>
        /// Project Id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Project Name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string ProjectName { get; set; }
        
        /// <summary>
        /// Project Type - Remote, In-house, External
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string ProjectType { get; set; }
        
        /// <summary>
        /// Client
        /// </summary>
        [JsonProperty(PropertyName = "clientid")]
        public Client ClientId { get; set; }
    }
}
