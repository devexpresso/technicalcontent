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
using command = EmployeeManagement.Api.Command.Client;
using model = EmployeeManagement.Model;

namespace EmployeeManagement.Api.Handler.Client
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteClient : IRequestHandler<command.DeleteClientCommand, BaseResponse>
    {
        private readonly IConfigurationProvider<model.Client> _provider;
        public DeleteClient(IConfigurationProvider<model.Client> provider, IMediator mediator)
        {
            _provider = provider;
        }
        public async Task<BaseResponse> Handle(command.DeleteClientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var client = await _provider.GetSpecificById(request.ClientId);
                if (client == null || !client.Any())
                    return new BaseResponse
                    {
                        ResponseStatusCode = StatusCodes.Status404NotFound,
                        Value = "Client don't exist!"
                    };
                var response = await _provider.Delete(request.ClientId);
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
