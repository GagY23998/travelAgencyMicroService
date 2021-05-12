using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.HotelService.Domain
{
    public class HotelRoom
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        public int Capacity { get; set; }
    }
}
