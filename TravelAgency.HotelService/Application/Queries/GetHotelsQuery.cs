using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Application.Queries
{
    public class GetHotelsQuery : IRequest<IEnumerable<HotelDTO>>
    {
        public HotelSearchRequest SearchRequest { get; }
        public GetHotelsQuery(HotelSearchRequest searchRequest)
        {
            SearchRequest = searchRequest;
        }

    }
}
