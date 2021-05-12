using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Common.Interfaces;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Application.Queries
{
    public class GetHotelOffersQueryHandler : IRequestHandler<GetHotelOffersQuery, IEnumerable<HotelOfferDTO>>
    {
        public GetHotelOffersQueryHandler(IHotelOfferRepository hotelOfferRepository)
        {
            HotelOfferRepository = hotelOfferRepository;
        }

        public IHotelOfferRepository HotelOfferRepository { get; }

        public async Task<IEnumerable<HotelOfferDTO>> Handle(GetHotelOffersQuery request, CancellationToken cancellationToken)
        {
            var result =  await HotelOfferRepository.Get(request.SearchRequest);
            return result != null ? result : null;
        }
    }
}
