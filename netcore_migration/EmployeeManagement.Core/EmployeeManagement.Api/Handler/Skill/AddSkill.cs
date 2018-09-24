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
using command = EmployeeManagement.Api.Command.Skill;
using model = EmployeeManagement.Model;
using System.Linq;

namespace EmployeeManagement.Api.Handler.Skill
{
    /// <summary>
    /// 
    /// </summary>
    public class AddSkill : IRequestHandler<command.AddSkillCommand, BaseResponse>
    {
        private readonly IConfigurationProvider<model.Skills> _provider;
        private readonly IMediator _mediator;
        public AddSkill(IConfigurationProvider<model.Skills> provider, IMediator mediator)
        {
            _provider = provider;
            _mediator = mediator;
        }

        public async Task<BaseResponse> Handle(command.AddSkillCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var key = _provider.GetAll().Result.Count() + 1;
                var skill = new model.Skills
                {
                    SkillId = key.ToString(),
                    SkillName = request.SkillName
                };

                var response = await _provider.Add(skill);
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
