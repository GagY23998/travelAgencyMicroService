using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Application.Commands
{
    public class CreateRoomTypeCommand : IRequest<RoomTypeDTO>
    {
        public CreateRoomTypeCommand(RoomTypeCreateRequest createRequest)
        {
            CreateRequest = createRequest;
        }

        public RoomTypeCreateRequest CreateRequest { get; }
    }
}
