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
using query = EmployeeManagement.Api.Query.Skills;
using model = EmployeeManagement.Model;

namespace EmployeeManagement.Api.Handler.Skill
{
    public class GetSkillById : IRequestHandler<query.GetSkillByIdQuery, BaseResponse>
    {
        private readonly IConfigurationProvider<model.Skills> _provider;
        public GetSkillById(IConfigurationProvider<model.Skills> provider)
        {
            _provider = provider;
        }

        public async Task<BaseResponse> Handle(query.GetSkillByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var skills = await _provider.GetSpecificById(request.SkillId);
                if (skills == null || !skills.Any())
                    return new BaseResponse
                    {
                        ResponseStatusCode = StatusCodes.Status404NotFound,
                        Value = "Skills not found"
                    };
                return new BaseResponse
                {
                    ResponseStatusCode = StatusCodes.Status302Found,
                    Value = skills
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
