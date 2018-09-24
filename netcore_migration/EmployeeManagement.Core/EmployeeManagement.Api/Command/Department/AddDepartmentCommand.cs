using EmployeeManagement.Api.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Command.Department
{
    public class AddDepartmentCommand : IRequest<BaseResponse>
    {
        public string DepartmentName { get; set; }
    }
}
