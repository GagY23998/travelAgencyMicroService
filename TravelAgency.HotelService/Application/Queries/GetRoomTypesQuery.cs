using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Application.Queries
{
    public class GetRoomTypesQuery : IRequest<IEnumerable<RoomTypeDTO>>
    {
        public GetRoomTypesQuery(RoomTypeSearchRequest searchRequest)
        {
            SearchRequest = searchRequest;
        }

        public RoomTypeSearchRequest SearchRequest { get; }
    }
}
