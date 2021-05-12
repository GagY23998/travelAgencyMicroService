using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.BookingService.Application.Commands
{
    public class ChangeBookingTransportOfferCommand : IRequest<bool>
    {
        public ChangeBookingTransportOfferCommand(Guid TransportOfferId)
        {
            this.TransportOfferId = TransportOfferId;
        }

        public Guid TransportOfferId { get; }
    }
}
