using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.TravelService.Domain.DTOs
{
    public class TransportReviewInsertRequest
    {
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }

    }
}
