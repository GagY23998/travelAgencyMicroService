using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.BookingService.Domain.BookingAggregate
{
    public class PaymentType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
