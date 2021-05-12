using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.DTOs;

namespace TravelAgency.BookingService.Application.Commands
{
    public class UpdateBookingCommand : IRequest<BookingDTO>
    {
        public Guid Id { get; set; }
        public BookingCreateRequest Request { get; set; }
        public UpdateBookingCommand(Guid Id,BookingCreateRequest request)
        {
            this.Id = Id;
            Request = request;
        }
    }
}
