using EmployeeManagement.Api.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Query.Client
{
    public class GetClientByIdQuery: IRequest<BaseResponse>
    {
        public int ClientId { get; set; }
    }
}
