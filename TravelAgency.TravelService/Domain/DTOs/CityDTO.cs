using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.TravelService.Domain.DTOs
{
    public class CityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TotalVisits { get; set; }
        public float Rating { get; set; }
        public string Image { get; set; } 
    }
}
