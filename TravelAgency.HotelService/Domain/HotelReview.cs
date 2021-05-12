using System;

namespace TravelAgency.HotelService.Domain
{
    public class HotelReview
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }         
    }
}