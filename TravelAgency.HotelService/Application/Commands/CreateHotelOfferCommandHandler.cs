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
    public class CreateHotelOfferCommandHandler : IRequestHandler<CreateHotelOfferCommand, HotelOfferDTO>
    {
        public CreateHotelOfferCommandHandler(IMediator mediator, IHotelOfferRepository hotelOfferRepository)
        {
            Mediator = mediator;
            HotelOfferRepository = hotelOfferRepository;
        }

        public IMediator Mediator { get; }
        public IHotelOfferRepository HotelOfferRepository { get; }

        public Task<HotelOfferDTO> Handle(CreateHotelOfferCommand request, CancellationToken cancellationToken)
        {
            var result = HotelOfferRepository.Add(request.CreateRequest);

            return result!=null ? Task.FromResult(result) : null;
        }
    }
}
