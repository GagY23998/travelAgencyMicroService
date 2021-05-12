using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.BookingAggregate;

namespace TravelAgency.BookingService.Application.Commands
{
    public class ChangeBookingTourOfferCommand : IRequest<bool>
    {
      
        public Guid TourOfferId { get; }
        public ChangeBookingTourOfferCommand(Guid tourOfferId)
        {
            TourOfferId = tourOfferId;
        }

    }
}
