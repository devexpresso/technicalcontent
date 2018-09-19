
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Model
{
    /// <summary>
    /// Skill Model
    /// </summary>
    public class Skills
    {
        /// <summary>
        /// Skill Id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int SkillId { get; set; }

        /// <summary>
        /// Skill Name
        /// </summary>
        [JsonProperty(PropertyName ="skillname")]
        public string SkillName { get; set; }
    }
}
