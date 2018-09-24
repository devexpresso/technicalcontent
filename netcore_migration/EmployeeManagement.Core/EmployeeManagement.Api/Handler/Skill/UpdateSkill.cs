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
using command = EmployeeManagement.Api.Command.Skill;
using model = EmployeeManagement.Model;

namespace EmployeeManagement.Api.Handler.Skill
{
    public class UpdateSkill : IRequestHandler<command.ModifySkillCommand, BaseResponse>
    {
        private readonly IConfigurationProvider<model.Skills> _provider;
        private readonly IMediator _mediator;

        public UpdateSkill(IConfigurationProvider<model.Skills> provider, IMediator mediator)
        {
            _provider = provider;
            _mediator = mediator;
        }
        public async Task<BaseResponse> Handle(command.ModifySkillCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var skills = await _provider.GetSpecificById(request.SkillId);
                if (skills == null || !skills.Any())
                    return new BaseResponse
                    {
                        ResponseStatusCode = StatusCodes.Status404NotFound,
                        Value = "Skill not found"
                    };

                var skill = new model.Skills
                {
                    SkillId = request.SkillId.ToString(),
                    SkillName = request.SkillName
                };

                var response = await _provider.Update(skill);
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
