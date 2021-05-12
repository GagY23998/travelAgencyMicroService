using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.BookingService.Application.Enumerations;

namespace TravelAgency.BookingService.Application.Commands
{
    public class ChangeBookingHotelOfferCommand : IRequest<bool>
    {
        public Guid HotelOfferId { get; }

        public ChangeBookingHotelOfferCommand(Guid HotelOfferId)
        {
            this.HotelOfferId = HotelOfferId;
        }

    }
}
