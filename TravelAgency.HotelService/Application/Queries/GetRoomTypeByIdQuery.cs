using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Application.Queries
{
    public class GetRoomTypeByIdQuery : IRequest<RoomTypeDTO>
    {
        public GetRoomTypeByIdQuery(object Id)
        {
            this.Id = Id;
        }

        public object Id { get; }
    }
}
