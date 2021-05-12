using System;
using TravelAgency.HotelService.Domain.Common;

namespace TravelAgency.HotelService.Domain.Models
{
    public class HotelReviewDTO
    {
        public int UserId { get; set; }
        public UserDTO User { get; set; }
        public int HotelId { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; } 
    }
}