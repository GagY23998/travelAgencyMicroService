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
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, RoleDTO>
    {
        public DeleteRoleCommandHandler(IMapper mapper, IRoleRepository roleRepository)
        {
            Mapper = mapper;
            RoleRepository = roleRepository;
        }

        public IMapper Mapper { get; }
        public IRoleRepository RoleRepository { get; }

        public Task<RoleDTO> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var result = RoleRepository.Remove(request.Id);
            return Task.FromResult(result);
        }
    }
}
