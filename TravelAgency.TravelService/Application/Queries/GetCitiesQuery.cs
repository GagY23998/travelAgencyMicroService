using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.TravelService.Domain.DTOs;

namespace TravelAgency.TravelService.Application.Queries
{
    public class GetCitiesQuery : IRequest<IEnumerable<CityDTO>>
    {
        public GetCitiesQuery(CitySearchRequest searchRequest)
        {
            SearchRequest = searchRequest;
        }

        public CitySearchRequest SearchRequest { get; }
    }
}
