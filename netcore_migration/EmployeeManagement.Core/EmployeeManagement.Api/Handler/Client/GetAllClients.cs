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
    public class GetAllClients : IRequestHandler<query.GetAllClientsQuery, BaseResponse>
    {
        private readonly IConfigurationProvider<model.Client> _provider;
        public GetAllClients(IConfigurationProvider<model.Client> provider)
        {
            _provider = provider;
        }
        public async Task<BaseResponse> Handle(query.GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var clients = await _provider.GetAll();
            if (clients == null || !clients.Any())
                return new BaseResponse
                {
                    ResponseStatusCode = StatusCodes.Status404NotFound,
                    Value = "No Clients found"
                };
            return new BaseResponse
            {
                ResponseStatusCode = StatusCodes.Status302Found,
                Value = clients
            };
        }
    }
}
