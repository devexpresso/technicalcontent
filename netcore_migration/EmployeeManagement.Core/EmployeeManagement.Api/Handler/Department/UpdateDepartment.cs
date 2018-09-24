using EmployeeManagement.Api.Query.Department;
using EmployeeManagement.Api.Query.Project;
using EmployeeManagement.Api.Request;
using EmployeeManagement.Api.Request.Employee;
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
    public class UpdateDepartment : IRequestHandler<command.ModifyDepartmentCommand, BaseResponse>
    {
        private readonly IConfigurationProvider<model.Department> _provider;
        private readonly IMediator _mediator;

        public UpdateDepartment(IConfigurationProvider<model.Department> provider, IMediator mediator)
        {
            _provider = provider;
            _mediator = mediator;
        }
        public async Task<BaseResponse> Handle(command.ModifyDepartmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var departments = await _provider.GetSpecificById(request.DepartmentId);
                if (departments == null || !departments.Any())
                    return new BaseResponse
                    {
                        ResponseStatusCode = StatusCodes.Status404NotFound,
                        Value = "Department not found"
                    };

                var department = new model.Department
                {
                    DepartmentId = request.DepartmentId.ToString(),
                    DepartnmentName = request.DepartmentName
                };

                var response = await _provider.Update(department);
                return new BaseResponse
                {
                    ResponseStatusCode = StatusCodes.Status200OK,
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
