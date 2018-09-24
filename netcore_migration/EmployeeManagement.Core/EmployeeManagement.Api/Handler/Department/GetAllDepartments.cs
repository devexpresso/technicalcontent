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
    public class GetAllDepartments : IRequestHandler<query.GetAllDepartmentsQuery, BaseResponse>
    {
        private readonly IConfigurationProvider<model.Department> _provider;
        public GetAllDepartments(IConfigurationProvider<model.Department> provider)
        {
            _provider = provider;
        }
        public async Task<BaseResponse> Handle(query.GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var departments = await _provider.GetAll();
            if (departments == null || !departments.Any())
                return new BaseResponse
                {
                    ResponseStatusCode = StatusCodes.Status404NotFound,
                    Value = "No Departments found"
                };
            return new BaseResponse
            {
                ResponseStatusCode = StatusCodes.Status302Found,
                Value = departments
            };
        }
    }
}
