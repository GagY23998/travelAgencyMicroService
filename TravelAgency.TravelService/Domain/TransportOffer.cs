using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace TravelAgency.TravelService.Domain
{
    public class TransportOffer
    {

        public Guid Id { get; set; }
        public int TransportCompanyId { get; set; }
        public TransportCompany TransportCompany { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public int TotalReservation { get; set; }
        public int CurrentReserved { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public float Price { get; set; }
        
    }
}
