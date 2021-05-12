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
    public class DeleteHotelOfferCommandHandler : IRequestHandler<DeleteHotelOfferCommand, HotelOfferDTO>
    {

        public DeleteHotelOfferCommandHandler(IMediator mediator, IHotelOfferRepository hotelOfferRepository)
        {
            Mediator = mediator;
            HotelOfferRepository = hotelOfferRepository;
        }

        public IMediator Mediator { get; }
        public IHotelOfferRepository HotelOfferRepository { get; }

        public Task<HotelOfferDTO> Handle(DeleteHotelOfferCommand request, CancellationToken cancellationToken)
        {

            var result = HotelOfferRepository.Remove(request.Id);


            return result != null ? Task.FromResult(result):null ;

        }
    }
}
