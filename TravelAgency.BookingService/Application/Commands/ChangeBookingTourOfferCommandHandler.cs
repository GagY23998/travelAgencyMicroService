using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.BookingAggregate;
using TravelAgency.BookingService.Domain.Repositories;

namespace TravelAgency.BookingService.Application.Commands
{
    public class ChangeBookingTourOfferCommandHandler : IRequestHandler<ChangeBookingTourOfferCommand, bool>
    {
        private readonly IMediator mediator;
        private readonly IBookingRepository bookingRepository;

        public ChangeBookingTourOfferCommandHandler(IMediator mediator,IBookingRepository bookingRepository)
        {
            this.mediator = mediator;
            this.bookingRepository = bookingRepository;
        }
        public Task<bool> Handle(ChangeBookingTourOfferCommand request, CancellationToken cancellationToken)
        {
            //var result = bookingRepository.ChangeTourOfferBooking(request.TourOfferId);
            
            return Task.FromResult(true);
            
        }
    }
}
