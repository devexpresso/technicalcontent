using EmployeeManagement.Api.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Command.Client
{
    public class DeleteClientCommand : IRequest<BaseResponse>
    {
        public int ClientId { get; set; }
    }
}
