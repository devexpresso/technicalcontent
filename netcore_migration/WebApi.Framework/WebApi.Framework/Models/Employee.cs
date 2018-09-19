using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Framework.Models
{
    /// <summary>
    /// Employee model
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        [JsonProperty(PropertyName = "firstname")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        [JsonProperty(PropertyName = "lastname")]
        public string LastName { get; set; }

        /// <summary>
        /// Date of Birth
        /// </summary>
        [JsonProperty(PropertyName = "dob")]
        public string DateOfBirth { get; set; }

        /// <summary>
        /// Department
        /// </summary>
        [JsonProperty(PropertyName = "department")]
        public string Department { get; set; }

        /// <summary>
        /// Project Id
        /// </summary>
        [JsonProperty(PropertyName = "projectid")]
        public string ProjectId { get; set; }

        /// <summary>
        /// Billable
        /// </summary>
        [JsonProperty(PropertyName = "billable")]
        public bool Billable { get; set; }
    }
}