using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.TravelService.Domain
{
    public class Attraction
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
