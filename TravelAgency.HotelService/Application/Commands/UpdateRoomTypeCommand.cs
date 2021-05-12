using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Application.Commands
{
    public class UpdateRoomTypeCommand : IRequest<RoomTypeDTO>
    {
        public UpdateRoomTypeCommand(object id, RoomTypeCreateRequest updateRequest)
        {
            Id = id;
            UpdateRequest = updateRequest;
        }

        public object Id { get; }
        public RoomTypeCreateRequest UpdateRequest { get; }
    }
}
