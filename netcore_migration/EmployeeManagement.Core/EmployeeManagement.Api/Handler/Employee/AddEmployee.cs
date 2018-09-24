using EmployeeManagement.Api.Query.Department;
using EmployeeManagement.Api.Query.Project;
using EmployeeManagement.Api.Request;
using EmployeeManagement.Api.Request.Employee;
using EmployeeManagement.Api.Response;

using EmployeeManagement.Provider.Interface;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Documents;
using System;
using System.Threading;
using System.Threading.Tasks;
using command = EmployeeManagement.Api.Command.Employee;
using model = EmployeeManagement.Model;
using System.Linq;

namespace EmployeeManagement.Api.Handler.Employee
{
    /// <summary>
    /// 
    /// </summary>
    public class AddEmployee : IRequestHandler<command.AddEmployeeCommand, BaseResponse>
    {
        private readonly IConfigurationProvider<model.Employee> _provider;
        private readonly IMediator _mediator;
        public AddEmployee(IConfigurationProvider<model.Employee> provider, IMediator mediator)
        {
            _provider = provider;
            _mediator = mediator;
        }

        public async Task<BaseResponse> Handle(command.AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var projectResponse = await _mediator.Send(new GetProjectByIdQuery { ProjectId = request.Project });
                if (projectResponse.ResponseStatusCode == StatusCodes.Status404NotFound)
                    return projectResponse;

                var departmentResponse = await _mediator.Send(new GetDepartmentByIdQuery { DepartmentId = request.Department });
                if (departmentResponse.ResponseStatusCode == StatusCodes.Status404NotFound)
                    return departmentResponse;

                var key = _provider.GetAll().Result.Count() + 1;
                var emp = new model.Employee
                {
                    EmployeeId = key.ToString(),
                    Role = request.Role,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    DateOfBirth = request.DOB,
                    Billable = request.Billable,
                    Project = (model.Project)projectResponse.Value,
                    Department = (model.Department)departmentResponse.Value
                };

                var response = await _provider.Add(emp);
                return new BaseResponse
                {
                    ResponseStatusCode = StatusCodes.Status201Created,
                    Value = response
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse
                {
                    ResponseStatusCode = StatusCodes.Status500InternalServerError,
                    Value = ex.Message
                };
            }
        }
    }
}
