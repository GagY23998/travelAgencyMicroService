using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.HotelService.Domain.Models
{
    public class HotelRoomSearchRequest
    {
        public int HotelId { get; set; }
        public int RoomTypeId { get; set; }
        public int Capacity { get; set; }
    }
}
