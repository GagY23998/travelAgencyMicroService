using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Queries
{
    public class GetTransportOfferByIdQuery : IRequest<TransportOfferDTO>
    {
        public GetTransportOfferByIdQuery(object Id)
        {
            this.Id = Id;
        }
        public object Id { get; }
    }
}
