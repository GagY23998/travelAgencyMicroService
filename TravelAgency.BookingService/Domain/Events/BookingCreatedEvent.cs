using System;
using TravelAgency.BookingService.Domain.BookingAggregate;
using TravelAgency.BookingService.Domain.Common;

namespace TravelAgency.BookingService.Domain.Events
{
    public class BookingCreatedEvent : IDomainEvent
    {
        public Guid _Id { get;  }
        public int UserId { get; }
        public long Version { get;  }
        public Guid HotelOfferId { get;  }
        public Guid TransportOfferId { get; }
        public DateTime ReservationDate { get; }
        public Payment Payment { get;  }
        public bool Status { get; }
        public bool Completed { get; }
        public BookingCreatedEvent(long version,Guid hotelOfferId,Guid transportOfferId,DateTime reservationDate,Payment payment, bool status)
        {
            _Id = Guid.NewGuid();
            Version = version;
            HotelOfferId = hotelOfferId;
            TransportOfferId = transportOfferId;
            ReservationDate = reservationDate;
            Payment = payment;
            Status = status;
        }
        public BookingCreatedEvent()
        {

        }
    }
}
