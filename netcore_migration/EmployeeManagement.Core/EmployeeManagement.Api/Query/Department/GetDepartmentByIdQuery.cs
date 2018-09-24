using EmployeeManagement.Api.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Query.Department
{
    public class GetDepartmentByIdQuery: IRequest<BaseResponse>
    {
        public int DepartmentId { get; set; }
    }
}
