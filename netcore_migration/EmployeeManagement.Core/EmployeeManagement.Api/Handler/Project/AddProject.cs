using EmployeeManagement.Api.Query.Client;
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
using System.Threading;
using System.Threading.Tasks;
using command = EmployeeManagement.Api.Command.Project;
using model = EmployeeManagement.Model;
using System.Linq;

namespace EmployeeManagement.Api.Handler.Project
{
    /// <summary>
    /// 
    /// </summary>
    public class AddProject : IRequestHandler<command.AddProjectCommand, BaseResponse>
    {
        private readonly IConfigurationProvider<model.Project> _provider;
        private readonly IMediator _mediator;
        public AddProject(IConfigurationProvider<model.Project> provider, IMediator mediator)
        {
            _provider = provider;
            _mediator = mediator;
        }

        public async Task<BaseResponse> Handle(command.AddProjectCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var client = await _mediator.Send(new GetClientByIdQuery { ClientId = request.ClientId });
                if (client.ResponseStatusCode == StatusCodes.Status404NotFound)
                    return client;

                var key = _provider.GetAll().Result.Count() + 1;

                var project = new model.Project
                {
                    Id = key.ToString(),
                    ProjectName = request.ProjectName,
                    ProjectType = request.ProjectType,
                    Client = (model.Client)client.Value
                };

                var response = await _provider.Add(project);
                return new BaseResponse
                {
                    ResponseStatusCode = StatusCodes.Status201Created,
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
