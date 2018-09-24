using EmployeeManagement.Api.Request;
using EmployeeManagement.Api.Response;
using EmployeeManagement.Model;
using EmployeeManagement.Provider.Interface;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using query = EmployeeManagement.Api.Query.Client;
using model = EmployeeManagement.Model;

namespace EmployeeManagement.Api.Handler.Client
{
    public class GetClientById : IRequestHandler<query.GetClientByIdQuery, BaseResponse>
    {
        private readonly IConfigurationProvider<model.Client> _provider;
        public GetClientById(IConfigurationProvider<model.Client> provider)
        {
            _provider = provider;
        }

        public async Task<BaseResponse> Handle(query.GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var clients = await _provider.GetSpecificById(request.ClientId);
                if (clients == null || !clients.Any())
                    return new BaseResponse
                    {
                        ResponseStatusCode = StatusCodes.Status404NotFound,
                        Value = "Clients not found"
                    };
                return new BaseResponse
                {
                    ResponseStatusCode = StatusCodes.Status302Found,
                    Value = clients
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
