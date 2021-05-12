using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.UserService.Domain.Common.Models;

namespace TravelAgency.UserService.Application.Commands
{
    public class DeleteRoleCommand : IRequest<RoleDTO>
    {
        public DeleteRoleCommand(object Id)
        {
            this.Id = Id;
        }

        public object Id { get; }
    }
}
