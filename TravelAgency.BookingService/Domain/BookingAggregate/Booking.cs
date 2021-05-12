using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.Common;
using TravelAgency.BookingService.Domain.Events;

namespace TravelAgency.BookingService.Domain.BookingAggregate
{
    public class Booking:Entity,IAggregateRoot
    {
        public int UserId {get; set;}
        public Guid HotelOfferId { get; set; }
        public Guid TransportOfferId { get; set; }
        public DateTime ReservationDate { get; set; }
        public Payment Payment { get; set; }
        public Guid PaymentId { get; set; }
        public bool CanceledStatus { get; set; }
        public bool Completed { get; set; }

        public void Apply(BookingCreatedEvent e)
        {
            Id = e._Id;
            UserId = e.UserId;
            HotelOfferId = e.HotelOfferId;
            TransportOfferId = e.TransportOfferId;
            ReservationDate = e.ReservationDate;
            Payment = e.Payment;
            CanceledStatus = e.Status;
        }

        public void Apply(BookingCanceledEvent e)
        {
            Id = e._Id;
            HotelOfferId = e.HotelOfferId;
            TransportOfferId = e.TransportOfferId;
            ReservationDate = e.ReservationDate;
            Payment = e.Payment;
            CanceledStatus = e.Status;
        }
        
        public void Apply(BookingCompletedEvent e)
        {
            Id = e._Id;
            HotelOfferId = e.HotelOfferId;
            TransportOfferId = e.TransportOfferId;
            ReservationDate = e.ReservationDate;
            Payment = e.Payment;
            CanceledStatus = e.Status;
            Completed = e.Completed;
        }

        public void CreateBooking(Guid tourOffer,Guid HotelOfferId,Guid TransportOffer,DateTime reservationDate,Payment payment)
        {
            bool condition = this.GetUnloadedEvents().Any(_ => _.GetType() != typeof(BookingCreatedEvent));
            if (!condition)
            {

                BookingCreatedEvent @event = new BookingCreatedEvent(this.Version + 1, HotelOfferId, TransportOffer, reservationDate, payment, false);
                this.AddEvent(@event);
            }
        }

        public void CancelBooking(Guid ID)
        {
            if(this.GetUnloadedEvents().Any(_=>_.GetType() == typeof(BookingCreatedEvent)) && this.Id == ID)
            {
                var e = new BookingCanceledEvent(Version + 1, HotelOfferId, TransportOfferId, ReservationDate, Payment, CanceledStatus, Completed);

                this.AddEvent(e);
            }
        }

        public void CompleteBooking()
        {
            if (!this.GetUnloadedEvents().Any(_ => _.GetType() == typeof(BookingCompletedEvent)))
            {
                var e = new BookingCompletedEvent(Version+1,HotelOfferId,TransportOfferId,ReservationDate,Payment,CanceledStatus,Completed);
                this.AddEvent(e);
            }
        }
    }
}
