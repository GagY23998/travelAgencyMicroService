using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.HotelService.Domain.Models
{
    public class HotelCreateRequest
    {
        public string Name { get; set; }
        public int CityId { get; set; }
        public List<HotelRoomCreateRequest> HotelRooms { get; set; }
        public string Description { get; set; }
    }
}
