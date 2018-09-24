using EmployeeManagement.Api.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Query.Skills
{
    public class GetSkillByIdQuery: IRequest<BaseResponse>
    {
        public int SkillId { get; set; }
    }
}
