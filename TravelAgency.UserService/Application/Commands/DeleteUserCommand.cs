  using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.UserService.Domain.Common.Models;

namespace TravelAgency.UserService.Application.Commands
{
    public class DeleteUserCommand : IRequest<UserDTO>
    {
        public DeleteUserCommand(object UserId)
        {
            this.Id = Id;
        }

        public object Id { get; }
    }
}
