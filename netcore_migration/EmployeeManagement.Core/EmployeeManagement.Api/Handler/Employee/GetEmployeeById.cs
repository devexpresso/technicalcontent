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
using query = EmployeeManagement.Api.Query.Employee;
using model = EmployeeManagement.Model;

namespace EmployeeManagement.Api.Handler.Employee
{
    public class GetEmployeeById : IRequestHandler<query.GetEmployeeByIdQuery, BaseResponse>
    {
        private readonly IConfigurationProvider<model.Employee> _provider;
        public GetEmployeeById(IConfigurationProvider<model.Employee> provider)
        {
            _provider = provider;
        }

        public async Task<BaseResponse> Handle(query.GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var employees = await _provider.GetSpecificById(request.EmployeeId);
                if (employees == null || !employees.Any())
                    return new BaseResponse
                    {
                        ResponseStatusCode = StatusCodes.Status404NotFound,
                        Value = "Employee not found"
                    };
                return new BaseResponse
                {
                    ResponseStatusCode = StatusCodes.Status302Found,
                    Value = employees
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
