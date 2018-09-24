using EmployeeManagement.Api.Query.Department;
using EmployeeManagement.Api.Query.Project;
using EmployeeManagement.Api.Request;
using EmployeeManagement.Api.Request.Employee;
using EmployeeManagement.Api.Response;
using EmployeeManagement.Model;
using EmployeeManagement.Provider.Interface;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using command = EmployeeManagement.Api.Command.Project;
using model = EmployeeManagement.Model;

namespace EmployeeManagement.Api.Handler.Project
{
    public class UpdateProject : IRequestHandler<command.ModifyProjectCommand, BaseResponse>
    {
        private readonly IConfigurationProvider<model.Project> _provider;
        private readonly IMediator _mediator;

        public UpdateProject(IConfigurationProvider<model.Project> provider, IMediator mediator)
        {
            _provider = provider;
            _mediator = mediator;
        }
        public async Task<BaseResponse> Handle(command.ModifyProjectCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var projects = await _provider.GetSpecificById(request.ProjectId);
                if (projects == null || !projects.Any())
                    return new BaseResponse
                    {
                        ResponseStatusCode = StatusCodes.Status404NotFound,
                        Value = "Project not found"
                    };

                var project = new model.Project
                {
                    Id = request.ProjectId.ToString(),
                    ProjectName = request.ProjectType
                };

                var response = await _provider.Update(project);
                return new BaseResponse
                {
                    ResponseStatusCode = StatusCodes.Status200OK,
                    Value = response
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse
                {
                    ResponseStatusCode = StatusCodes.Status500InternalServerError,
                    Value = ex
                };
            }
        }
    }
}
