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
    public class GetAllSkills : IRequestHandler<query.GetAllSkillsQuery, BaseResponse>
    {
        private readonly IConfigurationProvider<model.Client> _provider;
        public GetAllSkills(IConfigurationProvider<model.Client> provider)
        {
            _provider = provider;
        }
        public async Task<BaseResponse> Handle(query.GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = await _provider.GetAll();
            if (skills == null || !skills.Any())
                return new BaseResponse
                {
                    ResponseStatusCode = StatusCodes.Status404NotFound,
                    Value = "No Skills found"
                };
            return new BaseResponse
            {
                ResponseStatusCode = StatusCodes.Status302Found,
                Value = skills
            };
        }
    }
}
