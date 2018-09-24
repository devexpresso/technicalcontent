using EmployeeManagement.Api.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using model = EmployeeManagement.Model;

namespace EmployeeManagement.Api.Query.Employee
{
    public class GetEmployeeByFilterQuery : IRequest<BaseResponse>
    {
        public Expression<Func<model.Employee, bool>> IsBillable { get; set; }
    }
}
