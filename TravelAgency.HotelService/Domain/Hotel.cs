using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.HotelService.Domain
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public string Description { get; set; }
        public float Rating {get; set; }
        public IEnumerable<HotelReview> HotelReviews {get; set;}
    }
}
