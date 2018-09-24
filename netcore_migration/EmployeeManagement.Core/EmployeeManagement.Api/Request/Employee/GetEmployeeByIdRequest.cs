using EmployeeManagement.Api.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Request
{
    public class GetProjectByIdRequest : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}
