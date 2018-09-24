using EmployeeManagement.Api.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Command.Employee
{
    public class ModifyEmployeeCommand : IRequest<BaseResponse>
    {
        public int EmployeeId { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public int Department { get; set; }
        public int Project { get; set; }
        public List<int> Skills { get; set; }
        public bool Billable { get; set; }
    }
}
