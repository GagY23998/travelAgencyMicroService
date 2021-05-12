using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.BookingService.Application.Commands
{
    public class CancelBookingCommand : IRequest<bool>
    {
        private Guid id;
        public Guid Id { get { return id; } set { id = value; } }

        public CancelBookingCommand(Guid id)
        {
            this.id = id;
        }
    }
}
