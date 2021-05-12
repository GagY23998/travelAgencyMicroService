using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Queries
{
    public class GetTransportTypeByIdQuery : IRequest<TransportTypeDTO>
    {
        public GetTransportTypeByIdQuery(object id)
        {
            Id = id;
        }

        public object Id { get; }
    }
}
