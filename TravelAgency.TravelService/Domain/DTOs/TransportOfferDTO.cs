using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.TravelService.Domain.DTOs
{
    public class TransportOfferDTO
    {
        public Guid Id { get; set; }
        public int TransportCompanyId { get; set; }
        public TransportCompanyDTO TransportCompany { get; set; }
        public int CityId { get; set; }
        public CityDTO City { get; set; }
        public int TotalReservation { get; set; }
        public int CurrentReserved { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public float Price { get; set; }
    }
}
