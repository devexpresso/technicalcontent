using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EmployeeManagement.Model
{
    /// <summary>
    /// Employee model
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Employee Id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int EmployeeId { get; set; }

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
        public Department Department { get; set; }

        /// <summary>
        /// Project Id
        /// </summary>
        [JsonProperty(PropertyName = "projectid")]
        public Project ProjectId { get; set; }

        /// <summary>
        /// Skill Sets
        /// </summary>
        [JsonProperty(PropertyName ="skillsets")]
        public List<Skills> SkillSets { get; set; }
        /// <summary>
        /// Billable
        /// </summary>
        [JsonProperty(PropertyName = "billable")]
        public bool Billable { get; set; }
    }
}
