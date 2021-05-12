using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.TravelService.Domain.DTOs
{
    public class TourDTO
    {
        public Guid Id { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public IList<AttractionDTO> Attractions { get; set; }
    }
}
