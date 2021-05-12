using System;
namespace TravelAgency.HotelService.Domain.Models
{
    public class HotelReviewInsertRequest
    {
        public int HotelId { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }
}