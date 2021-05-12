using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.BookingAggregate;
using TravelAgency.BookingService.Domain.DTOs;

namespace TravelAgency.BookingService.Application.Commands
{
    public class CreateBookingCommand : IRequest<BookingDTO>
    {
        public BookingCreateRequest Booking { get; set; }

        public CreateBookingCommand(BookingCreateRequest request)
        {
            Booking = request;
        }
    }
}
