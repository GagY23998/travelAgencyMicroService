using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Common.Interfaces;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Application.Commands
{
    public class UpdateHotelOfferCommandHandler : IRequestHandler<UpdateHotelOfferCommand, HotelOfferDTO>
    {
        public UpdateHotelOfferCommandHandler(IHotelOfferRepository hotelOfferRepository)
        {
            HotelOfferRepository = hotelOfferRepository;
        }

        public IHotelOfferRepository HotelOfferRepository { get; }

        public Task<HotelOfferDTO> Handle(UpdateHotelOfferCommand request, CancellationToken cancellationToken)
        {

            var result = HotelOfferRepository.Update(request.Id, request.UpdateRequest);

            return Task.FromResult(result);
        }
    }
}
