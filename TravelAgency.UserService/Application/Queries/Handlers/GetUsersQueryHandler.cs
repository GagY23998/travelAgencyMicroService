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
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserDTO>>
    {
        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public IUserRepository UserRepository { get; }

        public Task<IEnumerable<UserDTO>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            
            var result = UserRepository.Get(request.SearchRequest);

            foreach (var item in result)
            {
                item.Picture = Encoding.UTF8.GetString(File.ReadAllBytes($"./Images/{item.FirstName + "-" + item.LastName}.png"));
            }

            return Task.FromResult(result);
        }
    }
}
