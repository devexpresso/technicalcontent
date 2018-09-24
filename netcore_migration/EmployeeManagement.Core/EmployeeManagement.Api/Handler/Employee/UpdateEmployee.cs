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
using command = EmployeeManagement.Api.Command.Employee;
using model = EmployeeManagement.Model;

namespace EmployeeManagement.Api.Handler.Employee
{
    public class UpdateEmployee : IRequestHandler<command.ModifyEmployeeCommand, BaseResponse>
    {
        private readonly IConfigurationProvider<model.Employee> _provider;
        private readonly IMediator _mediator;

        public UpdateEmployee(IConfigurationProvider<model.Employee> provider, IMediator mediator)
        {
            _provider = provider;
            _mediator = mediator;
        }
        public async Task<BaseResponse> Handle(command.ModifyEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var project = await _mediator.Send(new GetProjectByIdQuery { ProjectId = request.Project });
                if (project.ResponseStatusCode == StatusCodes.Status404NotFound)
                    return project;

                var department = await _mediator.Send(new GetDepartmentByIdQuery { DepartmentId = request.Department });
                if (department.ResponseStatusCode == StatusCodes.Status404NotFound)
                    return department;

                var emp = new model.Employee
                {
                    EmployeeId = request.EmployeeId.ToString(),
                    Role = request.Role,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    DateOfBirth = request.DOB,
                    Billable = request.Billable,
                    Project = (model.Project)project.Value,
                    Department = (model.Department)department.Value
                };

                var response = await _provider.Update(emp);
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
