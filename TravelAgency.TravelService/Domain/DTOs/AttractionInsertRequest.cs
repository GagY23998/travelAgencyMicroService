using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.TravelService.Domain.DTOs
{
    public class AttractionInsertRequest
    {
        public int TourId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
