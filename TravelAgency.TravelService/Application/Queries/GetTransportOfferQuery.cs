using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Queries
{
    public class GetTransportOfferQuery : IRequest<IEnumerable<TransportOfferDTO>>
    {
        public TransportOfferSearchRequest SearchRequest { get; set; }
        public GetTransportOfferQuery(TransportOfferSearchRequest searchRequest)
        {
            SearchRequest = searchRequest;
        }

    }
}
