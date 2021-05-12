using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.Repositories;

namespace TravelAgency.BookingService.Application.Commands
{
    public class CancelBookingCommandHandler : IRequestHandler<CancelBookingCommand, bool>
    {
        private readonly IMediator mediator;
        private readonly IBookingRepository bookingRepository;

        public CancelBookingCommandHandler(IMediator mediator,IBookingRepository bookingRepository)
        {
            this.mediator = mediator;
            this.bookingRepository = bookingRepository;
        }
        public Task<bool> Handle(CancelBookingCommand request, CancellationToken cancellationToken)
        {
            var result = bookingRepository.CancelBooking(request.Id);
            return Task.FromResult(result);
        }
    }
}
