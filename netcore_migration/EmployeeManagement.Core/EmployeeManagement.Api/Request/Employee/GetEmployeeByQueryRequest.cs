using EmployeeManagement.Api.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Request
{
    public class GetProjectByQueryRequest<Employee> : IRequest<BaseResponse>
    {
        public Expression<Func<Employee, bool>> Predicate { get; set; }
    }
}
