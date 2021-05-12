using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Application.Commands
{
    public class DeleteRoomTypeCommand : IRequest<RoomTypeDTO>
    {
        public DeleteRoomTypeCommand(object Id)
        {
            this.Id = Id;
        }

        public object Id { get; }
    }
}
