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
using query = EmployeeManagement.Api.Query.Project;
using model = EmployeeManagement.Model;

namespace EmployeeManagement.Api.Handler.Project
{
    public class GetAllProjects : IRequestHandler<query.GetAllProjectsQuery, BaseResponse>
    {
        private readonly IConfigurationProvider<model.Project> _provider;
        public GetAllProjects(IConfigurationProvider<model.Project> provider)
        {
            _provider = provider;
        }
        public async Task<BaseResponse> Handle(query.GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _provider.GetAll();
            if (projects == null || !projects.Any())
                return new BaseResponse
                {
                    ResponseStatusCode = StatusCodes.Status404NotFound,
                    Value = "No Projects found"
                };
            return new BaseResponse
            {
                ResponseStatusCode = StatusCodes.Status302Found,
                Value = projects
            };
        }
    }
}
