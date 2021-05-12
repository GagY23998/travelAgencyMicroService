using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.Repositories;

namespace TravelAgency.BookingService.Application.Commands
{ 
    public class DeleteBookingCommand : IRequest<bool>
    {
        public Guid BookingId { get; }
        public DeleteBookingCommand(Guid id) => BookingId = id;

    }
}
