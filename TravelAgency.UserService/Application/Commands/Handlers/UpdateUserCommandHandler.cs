using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.UserService.Domain.Common.Interfaces;
using TravelAgency.UserService.Domain.Common.Models;

namespace TravelAgency.UserService.Application.Commands.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDTO>
    {
        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public IUserRepository UserRepository { get; }

        public Task<UserDTO> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var result =  UserRepository.Update(request.Id, request.Request);

            return Task.FromResult(result);
        }
    }
}
