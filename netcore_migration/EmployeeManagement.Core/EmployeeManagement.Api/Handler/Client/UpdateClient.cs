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
using command = EmployeeManagement.Api.Command.Client;
using model = EmployeeManagement.Model;

namespace EmployeeManagement.Api.Handler.Client
{
    public class UpdateClient : IRequestHandler<command.ModifyClientCommand, BaseResponse>
    {
        private readonly IConfigurationProvider<model.Client> _provider;
        private readonly IMediator _mediator;

        public UpdateClient(IConfigurationProvider<model.Client> provider, IMediator mediator)
        {
            _provider = provider;
            _mediator = mediator;
        }
        public async Task<BaseResponse> Handle(command.ModifyClientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var clients = await _provider.GetSpecificById(request.ClientId);
                if (clients == null || !clients.Any())
                    return new BaseResponse
                    {
                        ResponseStatusCode = StatusCodes.Status404NotFound,
                        Value = "Client not found"
                    };

                var client = new model.Client
                {
                    ClientId = request.ClientId.ToString(),
                    ClientName = request.ClientName,
                    ClientLocation = request.ClientLocation
                };

                var response = await _provider.Update(client);
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
