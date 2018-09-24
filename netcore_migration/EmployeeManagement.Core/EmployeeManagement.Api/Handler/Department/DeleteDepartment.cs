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
using command = EmployeeManagement.Api.Command.Department;
using model = EmployeeManagement.Model;

namespace EmployeeManagement.Api.Handler.Department
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteDepartment : IRequestHandler<command.DeleteDepartmentCommand, BaseResponse>
    {
        private readonly IConfigurationProvider<model.Department> _provider;
        public DeleteDepartment(IConfigurationProvider<model.Department> provider, IMediator mediator)
        {
            _provider = provider;
        }
        public async Task<BaseResponse> Handle(command.DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var department = await _provider.GetSpecificById(request.DepartmentId);
                if (department == null || !department.Any())
                    return new BaseResponse
                    {
                        ResponseStatusCode = StatusCodes.Status404NotFound,
                        Value = "Department don't exist!"
                    };
                var response = await _provider.Delete(request.DepartmentId);
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
