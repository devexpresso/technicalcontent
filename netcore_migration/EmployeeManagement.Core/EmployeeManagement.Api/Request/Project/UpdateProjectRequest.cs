using EmployeeManagement.Api.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Request.Employee
{
    public class UpdateProjectRequest : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public string Role { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DateOfBirth { get; set; }

        public int Department { get; set; }

        public int Project { get; set; }

        public List<int> SkillSets { get; set; }

        public bool Billable { get; set; }
    }
}
