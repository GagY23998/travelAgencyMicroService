using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.HotelService.Domain.Models
{
    public class HotelOfferDTO
    {
        public Guid Id { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime StartDate { get; set; }
        public int HotelId { get; set; }
        public HotelDTO Hotel { get; set; }
        public HotelRoomDTO HotelRoom { get; set; }
        public int HotelRoomId { get; set; }
        public int NumberOfRooms { get; set; }
        public bool OfferStarted { get; set; }
        public bool OfferFinished { get; set; }
        public double Price { get; set; }
    }
}
