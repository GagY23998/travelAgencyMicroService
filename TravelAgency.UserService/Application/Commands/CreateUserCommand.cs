using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.UserService.Domain;
using TravelAgency.UserService.Domain.Common.Interfaces;
using TravelAgency.UserService.Domain.Common.Models;

namespace TravelAgency.UserService.Application.Commands
{
    public class CreateUserCommand : IRequest<UserDTO>
    {
        public CreateUserCommand(UserInsertRequest newUser)
        {
            NewUser = newUser;
        }

        public UserInsertRequest NewUser { get; }
    }
}
