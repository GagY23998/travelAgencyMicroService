using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.UserService.Domain.Common.Models;

namespace TravelAgency.UserService.Application.Queries
{
    public class GetUserByIdQuery : IRequest<UserDTO>
    {
        public GetUserByIdQuery(Guid Id)
        {
            this.Id = Id;
        }

        public Guid Id { get; }
    }
}
