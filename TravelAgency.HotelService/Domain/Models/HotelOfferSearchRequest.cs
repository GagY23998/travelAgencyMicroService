using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.HotelService.Domain.Models
{
    public class HotelOfferSearchRequest
    {
        public int CityId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime StartDate { get; set; }
        public string HotelName { get; set; }
        public int HotelRoomId { get; set; }
        public int NumberOfRooms { get; set; }
        public double Price { get; set; }
    }
}
