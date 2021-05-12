using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Application.Queries
{
    public class GetHotelRoomsQuery : IRequest<IEnumerable<HotelRoomDTO>>
    {
        public GetHotelRoomsQuery(HotelRoomSearchRequest searchRequest)
        {
            SearchRequest = searchRequest;
        }

        public HotelRoomSearchRequest SearchRequest { get; }
    }
}
