using AutoMapper;
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
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, UserDTO>
    {
        public DeleteUserCommandHandler(IMapper mapper, IUserRepository userRepository, IUserRoleRepository userRoleRepository)
        {
            Mapper = mapper;
            UserRepository = userRepository;
            UserRoleRepository = userRoleRepository;
        }

        public IMapper Mapper { get; }
        public IUserRepository UserRepository { get; }
        public IUserRoleRepository UserRoleRepository { get; }

        public Task<UserDTO> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userRoles = UserRoleRepository.Get(new UserRoleSearchRequest { UserId = (int)request.Id });
            
            UserRoleRepository.RemoveUserRole((int)request.Id);
            
            var result = UserRepository.Remove(request.Id);
            return Task.FromResult(result);
        }
    }
}
