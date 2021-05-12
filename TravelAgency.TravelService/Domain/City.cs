using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.TravelService.Domain
{
    public class City
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TotalVisits { get; set; }
        public float Rating { get; set; }
    }
}
