using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.TravelService.Domain
{
    public class TransportCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TransportTypeId { get; set; }
        public TransportType TransportType { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public int TotalTravels { get; set; }
        public float Rating { get; set; }
    }
}
