using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Queries.Handlers
{
    public class GetAttractionsQuery :IRequest<IEnumerable<AttractionDTO>>
    {
        public GetAttractionsQuery(AttractionSearchRequest searchRequest)
        {
            SearchRequest = searchRequest;
        }
        public AttractionSearchRequest SearchRequest { get; }
    }
}
