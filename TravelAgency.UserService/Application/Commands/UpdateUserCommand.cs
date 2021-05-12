using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.UserService.Domain.Common.Models;

namespace TravelAgency.UserService.Application.Commands
{
    public class UpdateUserCommand : IRequest<UserDTO>
    {
        public UpdateUserCommand(object Id, UserInsertRequest request)
        {
            this.Id = Id;
            Request = request;
        }

        public object Id { get; }
        public UserInsertRequest Request { get; }
    }
}
