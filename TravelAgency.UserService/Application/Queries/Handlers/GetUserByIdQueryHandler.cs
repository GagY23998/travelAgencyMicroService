using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.UserService.Domain.Common.Interfaces;
using TravelAgency.UserService.Domain.Common.Models;

namespace TravelAgency.UserService.Application.Queries.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDTO>
    {
        public GetUserByIdQueryHandler(IMapper mapper,IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public IUserRepository UserRepository { get; }

        public Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var result = UserRepository.GetById(request.Id);

            result.Picture = Encoding.UTF8.GetString(File.ReadAllBytes($"./Images/{result.FirstName + "-" + result.LastName}.png"));
            
            return Task.FromResult(result);
        }
    }
}
