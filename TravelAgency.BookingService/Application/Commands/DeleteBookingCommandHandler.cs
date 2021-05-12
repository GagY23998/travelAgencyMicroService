using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.Repositories;

namespace TravelAgency.BookingService.Application.Commands
{
    public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand, bool>
    {
        private readonly IMediator mediator;
        private readonly IBookingRepository bookingRepository;

        public DeleteBookingCommandHandler(IMediator mediator,IBookingRepository bookingRepository)
        {
            this.mediator = mediator;
            this.bookingRepository = bookingRepository;
        }
        public Task<bool> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            bool result = bookingRepository.DeleteBooking(request.BookingId);

            return Task.FromResult(result);
        }
    }
}
