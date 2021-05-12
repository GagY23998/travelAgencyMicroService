using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.TravelService.Domain.DTOs
{
    public class TransportReviewDTO
    {
        public int Id { get; set; }
        public int TrasnsportCompanyId { get; set; }
        public DateTime Date { get; set; }
        public float Rating { get; set; }

        public string Comment { get; set; }
    }
}
