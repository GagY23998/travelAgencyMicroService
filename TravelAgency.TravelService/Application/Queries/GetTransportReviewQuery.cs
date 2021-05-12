using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Queries
{
    public class GetTransportReviewQuery : IRequest<IEnumerable<TransportReviewDTO>>
    {
        public GetTransportReviewQuery(TransportReviewSearchRequest searchRequest)
        {
            SearchRequest = searchRequest;
        }

        public TransportReviewSearchRequest SearchRequest { get; }
    }
}
