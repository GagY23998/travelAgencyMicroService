using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.HotelService.Domain.Models
{
    public class HotelRoomCreateRequest
    {
        public int HotelId { get; set; }
        public int RoomTypeId { get; set; }
        public int Capacity { get; set; }
    }
}
