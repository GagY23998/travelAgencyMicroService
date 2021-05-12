using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.BookingService.Domain.DTOs
{
    public class PaymentCreateRequest
    {
        public DateTime PaymentDate { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }
    }
}
