using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.BookingAggregate;
using TravelAgency.BookingService.Domain.Common;

namespace TravelAgency.BookingService.Domain.Events
{
    public class BookingCompletedEvent : IDomainEvent
    {
        public Guid _Id { get; }
        public int UserId { get; set; }
        public long Version { get; }
        public Guid HotelOfferId { get; }
        public Guid TransportOfferId { get; }
        public DateTime ReservationDate { get; }
        public Payment Payment { get; }
        public bool Status { get; }
        public bool Completed { get; }
        public BookingCompletedEvent(long version, Guid hotelOfferId, Guid transportOfferId, DateTime reservationDate, Payment payment, bool status,bool completed)
        {
            _Id = Guid.NewGuid();
            Version = version;
            HotelOfferId = hotelOfferId;
            TransportOfferId = transportOfferId;
            ReservationDate = reservationDate;
            Payment = payment;
            Completed = completed;
        }
        public BookingCompletedEvent()
        {

        }
    }
}
