using EmployeeManagement.Api.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Command.Employee
{
    public class DeleteEmployeeCommand : IRequest<BaseResponse>
    {
        public int EmployeeId { get; set; }
    }
}
