using EmployeeManagement.Api.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Command.Department
{
    public class DeleteDepartmentCommand:IRequest<BaseResponse>
    {
        public int DepartmentId { get; set; }
    }
}
