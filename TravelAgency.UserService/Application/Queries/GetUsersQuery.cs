using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.UserService.Domain.Common.Models;

namespace TravelAgency.UserService.Application.Queries
{
    public class GetUsersQuery : IRequest<IEnumerable<UserDTO>>
    {
        public GetUsersQuery(UserSearchRequest searchRequest)
        {
            SearchRequest = searchRequest;
        }

        public UserSearchRequest SearchRequest { get; }
    }
}
