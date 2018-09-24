using EmployeeManagement.Api.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Command.Skill
{
    public class ModifySkillCommand : IRequest<BaseResponse>
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
    }
}
