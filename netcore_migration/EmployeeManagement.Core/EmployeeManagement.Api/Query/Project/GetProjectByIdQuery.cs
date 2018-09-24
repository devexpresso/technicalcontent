using EmployeeManagement.Api.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Query.Project
{
    public class GetProjectByIdQuery : IRequest<BaseResponse>
    {
        public int ProjectId { get; set; }
    }
}
