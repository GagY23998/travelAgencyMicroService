using System;

namespace TravelAgency.HotelService.Domain.Models
{
    public class HotelReviewSearchRequest
    {
        public DateTime Date { get; set; }
        public int HotelId { get; set; }
    }
}