using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.TravelService.Domain.DTOs
{
    public class TransportOfferSearchRequest
    {
        public string CompanyName { get; set; }
        public int CityId { get; set; }
        public int TotalReservation { get; set; }
        public int CurrentReserved { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
