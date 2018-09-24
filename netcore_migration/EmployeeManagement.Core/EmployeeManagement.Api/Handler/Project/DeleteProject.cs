using EmployeeManagement.Api.Request;
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
    /// <summary>
    /// 
    /// </summary>
    public class DeleteProject : IRequestHandler<command.DeleteProjectCommand, BaseResponse>
    {
        private readonly IConfigurationProvider<model.Project> _provider;
        public DeleteProject(IConfigurationProvider<model.Project> provider, IMediator mediator)
        {
            _provider = provider;
        }
        public async Task<BaseResponse> Handle(command.DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var project = await _provider.GetSpecificById(request.ProjectId);
                if (project == null || !project.Any())
                    return new BaseResponse
                    {
                        ResponseStatusCode = StatusCodes.Status404NotFound,
                        Value = "Project don't exist!"
                    };
                var response = await _provider.Delete(request.ProjectId);
                return new BaseResponse
                {
                    ResponseStatusCode = StatusCodes.Status202Accepted,
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
