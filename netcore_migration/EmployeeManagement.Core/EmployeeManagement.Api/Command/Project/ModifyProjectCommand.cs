using EmployeeManagement.Api.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Command.Project
{
    public class ModifyProjectCommand : IRequest<BaseResponse>
    {
        public int ProjectId { get; set; }
        public string ProjectType { get; set; }
    }
}
