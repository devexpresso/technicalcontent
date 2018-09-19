using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Model
{
    /// <summary>
    /// Department model
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Department Id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int DepartmentId { get; set; }

        /// <summary>
        /// Department Name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string DepartnmentName { get; set; }
    }
}
