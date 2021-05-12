using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.Repositories;

namespace TravelAgency.BookingService.Application.Commands
{
    public class ChangeBookingHotelOfferCommandHandler : IRequestHandler<ChangeBookingHotelOfferCommand, bool>
    {
        private readonly IMediator mediator;
        private readonly IBookingRepository bookingRepository;

        public ChangeBookingHotelOfferCommandHandler(IMediator mediator,IBookingRepository bookingRepository)
        {
            this.mediator = mediator;
            this.bookingRepository = bookingRepository;
        }
        public Task<bool> Handle(ChangeBookingHotelOfferCommand request, CancellationToken cancellationToken)
        {
            var result = bookingRepository.ChangeHotelOfferBooking(request.HotelOfferId);

            if (result != null)
            {
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
