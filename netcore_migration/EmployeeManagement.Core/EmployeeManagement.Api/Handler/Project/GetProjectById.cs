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
    public class GetProjectById : IRequestHandler<query.GetProjectByIdQuery, BaseResponse>
    {
        private readonly IConfigurationProvider<model.Project> _provider;
        public GetProjectById(IConfigurationProvider<model.Project> provider)
        {
            _provider = provider;
        }

        public async Task<BaseResponse> Handle(query.GetProjectByIdQuery request, CancellationToken cancellationToken)
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
                return new BaseResponse
                {
                    ResponseStatusCode = StatusCodes.Status302Found,
                    Value = projects
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
