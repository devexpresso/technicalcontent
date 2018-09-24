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
using query = EmployeeManagement.Api.Query.Department;
using model = EmployeeManagement.Model;

namespace EmployeeManagement.Api.Handler.Department
{
    public class GetDepartmentById : IRequestHandler<query.GetDepartmentByIdQuery, BaseResponse>
    {
        private readonly IConfigurationProvider<model.Department> _provider;
        public GetDepartmentById(IConfigurationProvider<model.Department> provider)
        {
            _provider = provider;
        }

        public async Task<BaseResponse> Handle(query.GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var departments = await _provider.GetSpecificById(request.DepartmentId);
                if (departments == null || !departments.Any())
                    return new BaseResponse
                    {
                        ResponseStatusCode = StatusCodes.Status404NotFound,
                        Value = "Deparmtent not found"
                    };
                return new BaseResponse
                {
                    ResponseStatusCode = StatusCodes.Status302Found,
                    Value = departments
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
