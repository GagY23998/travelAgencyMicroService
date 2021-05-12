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
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, RoleDTO>
    {
        public CreateRoleCommandHandler(IMapper mapper, IRoleRepository roleRepository)
        {
            Mapper = mapper;
            RoleRepository = roleRepository;
        }

        public IMapper Mapper { get; }
        public IRoleRepository RoleRepository { get; }

        public Task<RoleDTO> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var insertResult = RoleRepository.Add(request.InsertRequest);

            return insertResult != null ? Task.FromResult(insertResult) : null;
        }
    }
}
