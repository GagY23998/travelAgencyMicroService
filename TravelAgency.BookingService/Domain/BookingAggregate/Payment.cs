using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.Common;

namespace TravelAgency.BookingService.Domain.BookingAggregate
{
    public class Payment : Entity
    {
        public DateTime PaymentDate { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }

    }
}
