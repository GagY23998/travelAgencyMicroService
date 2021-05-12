using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.BookingAggregate;

namespace TravelAgency.BookingService.Domain.DTOs
{
    public class BookingCreateRequest
    {
        public Guid TourOffer { get; set; }
        public Guid HotelOffer { get; set; }
        public Guid TransportOffer { get; set; }
        public DateTime ReservationDate { get; set; }
        public Payment Payment { get; set; }
        public bool CanceledStatus { get; set; }
        public bool Completed { get; set; }
    }
}
