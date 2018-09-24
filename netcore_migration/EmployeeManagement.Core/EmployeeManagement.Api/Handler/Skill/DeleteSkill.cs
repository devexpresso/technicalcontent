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
using command = EmployeeManagement.Api.Command.Skill;
using model = EmployeeManagement.Model;

namespace EmployeeManagement.Api.Handler.Skill
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteSkill : IRequestHandler<command.DeleteSkillCommand, BaseResponse>
    {
        private readonly IConfigurationProvider<model.Skills> _provider;
        public DeleteSkill(IConfigurationProvider<model.Skills> provider, IMediator mediator)
        {
            _provider = provider;
        }
        public async Task<BaseResponse> Handle(command.DeleteSkillCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var skill = await _provider.GetSpecificById(request.SkillId);
                if (skill == null || !skill.Any())
                    return new BaseResponse
                    {
                        ResponseStatusCode = StatusCodes.Status404NotFound,
                        Value = "Skill don't exist!"
                    };
                var response = await _provider.Delete(request.SkillId);
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
