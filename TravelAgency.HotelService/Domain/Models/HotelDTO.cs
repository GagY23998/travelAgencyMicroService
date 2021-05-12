using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.HotelService.Domain.Models
{
    public class HotelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }   
        public IEnumerable<HotelReviewDTO> hotelReviews {get;set;}
    }
}
