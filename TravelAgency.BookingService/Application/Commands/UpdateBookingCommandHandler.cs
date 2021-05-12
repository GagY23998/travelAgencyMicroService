using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.DTOs;
using TravelAgency.BookingService.Domain.Repositories;

namespace TravelAgency.BookingService.Application.Commands
{
    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, BookingDTO>
    {
        private readonly IMediator mediator;
        private readonly IBookingRepository bookingRepository;

        public UpdateBookingCommandHandler(IMediator mediator, IBookingRepository bookingRepository)
        {
            this.mediator = mediator;
            this.bookingRepository = bookingRepository;
        }
        public Task<BookingDTO> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {

            var result = bookingRepository.UpdateBooking(request.Id,request.Request);

            return Task.FromResult(result);
        }
    }
}
