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
    public class GetHotelOfferByIdQueryHandler : IRequestHandler<GetHotelOfferByIdQuery,HotelOfferDTO>
    {
        public GetHotelOfferByIdQueryHandler(IHotelOfferRepository hotelOfferRepository)
        {
            HotelOfferRepository = hotelOfferRepository;
        }

        public IHotelOfferRepository HotelOfferRepository { get; }

        public Task<HotelOfferDTO> Handle(GetHotelOfferByIdQuery request, CancellationToken cancellationToken)
        {
            var result = HotelOfferRepository.GetById(request.Id);
            return result != null ? Task.FromResult(result) : null;
        }
    }
}
