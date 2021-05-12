using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Application.Queries
{
    public class GetHotelOffersQuery : IRequest<IEnumerable<HotelOfferDTO>>
    {
        public GetHotelOffersQuery(HotelOfferSearchRequest searchRequest)
        {
            SearchRequest = searchRequest;
        }

        public HotelOfferSearchRequest SearchRequest { get; }
    }
}
