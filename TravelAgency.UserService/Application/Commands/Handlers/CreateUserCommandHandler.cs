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
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDTO>
    {

        public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository, IUserRoleRepository userRolesRepository)
        {
            Mapper = mapper;
            UserRepository = userRepository;
            UserRolesRepository = userRolesRepository;
        }

        public IMapper Mapper { get; }
        public IUserRepository UserRepository { get; }
        public IUserRoleRepository UserRolesRepository { get; }

        public Task<UserDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var insertResult = UserRepository.Add(request.NewUser);

            foreach (var item in request.NewUser.UserRoles)
            {
                UserRolesRepository.Add(item);
            }

            return insertResult!=null ?Task.FromResult(insertResult): null;
        }
    }
}
