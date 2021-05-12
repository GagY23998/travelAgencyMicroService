using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.TravelService.Domain.DTOs
{
    public class TransportCompanySearchRequest
    {
        public string Name { get; set; }
        public int CityId { get; set; }
        public int TotalTravels { get; set; }
        public float Rating { get; set; }
    }
}
