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
using command = EmployeeManagement.Api.Command.Employee;
using model = EmployeeManagement.Model;

namespace EmployeeManagement.Api.Handler.Employee
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteEmployee : IRequestHandler<command.DeleteEmployeeCommand, BaseResponse>
    {
        private readonly IConfigurationProvider<model.Employee> _provider;
        public DeleteEmployee(IConfigurationProvider<model.Employee> provider, IMediator mediator)
        {
            _provider = provider;
        }
        public async Task<BaseResponse> Handle(command.DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var employee = await _provider.GetSpecificById(request.EmployeeId);
                if (employee == null || !employee.Any())
                    return new BaseResponse
                    {
                        ResponseStatusCode = StatusCodes.Status404NotFound,
                        Value = "Employee don't exist!"
                    };
                var response = await _provider.Delete(request.EmployeeId);
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
