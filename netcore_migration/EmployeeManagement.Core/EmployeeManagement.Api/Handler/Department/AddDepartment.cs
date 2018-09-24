using EmployeeManagement.Api.Query.Client;
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
using System.Threading;
using System.Threading.Tasks;
using command = EmployeeManagement.Api.Command.Department;
using model = EmployeeManagement.Model;
using System.Linq;

namespace EmployeeManagement.Api.Handler.Department
{
    /// <summary>
    /// 
    /// </summary>
    public class AddDepartment : IRequestHandler<command.AddDepartmentCommand, BaseResponse>
    {
        private readonly IConfigurationProvider<model.Department> _provider;
        private readonly IMediator _mediator;
        public AddDepartment(IConfigurationProvider<model.Department> provider, IMediator mediator)
        {
            _provider = provider;
            _mediator = mediator;
        }

        public async Task<BaseResponse> Handle(command.AddDepartmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var key = _provider.GetAll().Result.Count() + 1;
                var department = new model.Department
                {
                    DepartmentId = key.ToString(),
                    DepartnmentName = request.DepartmentName
                };

                var response = await _provider.Add(department);
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
                    Value = ex
                };
            }
        }
    }
}
