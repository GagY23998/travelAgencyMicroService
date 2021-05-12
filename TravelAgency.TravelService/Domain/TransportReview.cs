using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.TravelService.Domain
{
    public class TransportReview
    {
        public int Id { get; set; }
        public int TransportCompanyId { get; set; }
        public TransportCompany TransportCompaony { get; set; }
        public DateTime Date { get; set; }
        public float Rating { get; set; }
        public string Comment { get; set; }
    }
}
