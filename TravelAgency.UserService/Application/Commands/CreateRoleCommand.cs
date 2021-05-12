using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.UserService.Domain;
using TravelAgency.UserService.Domain.Common.Models;

namespace TravelAgency.UserService.Application.Commands
{
    public class CreateRoleCommand : IRequest<RoleDTO>
    {
        public CreateRoleCommand(RoleInsertRequest insertRequest)
        {
            InsertRequest = insertRequest;
        }

        public RoleInsertRequest InsertRequest { get; }
    }
}
