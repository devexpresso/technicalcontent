using EmployeeManagement.Api.Response;
using MediatR;
using Microsoft.Azure.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Request
{
    public class DeleteProjectRequest : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}
