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
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using command = EmployeeManagement.Api.Command.Client;
using model = EmployeeManagement.Model;
using System.Linq;

namespace EmployeeManagement.Api.Handler.Client
{
    /// <summary>
    /// 
    /// </summary>
    public class AddClient : IRequestHandler<command.AddClientCommand, BaseResponse>
    {
        private readonly IConfigurationProvider<model.Client> _provider;
        private readonly IMediator _mediator;
        public AddClient(IConfigurationProvider<model.Client> provider, IMediator mediator)
        {
            _provider = provider;
            _mediator = mediator;
        }

        public async Task<BaseResponse> Handle(command.AddClientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var key = _provider.GetAll().Result.Count() + 1;
                var client = new model.Client
                {
                    ClientId = key.ToString(),
                    ClientName = request.ClientName,
                    ClientLocation = request.ClientLocation
                };

                var response = await _provider.Add(client);
                return new BaseResponse
                {
                    ResponseStatusCode = StatusCodes.Status201Created,
                    Value = response
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    ResponseStatusCode = StatusCodes.Status500InternalServerError,
                    Value = ex.Message
                };
            }
        }
    }
}
