using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Common;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Application.Commands
{
    public class UpdateRoomTypeCommandHandler : IRequestHandler<UpdateRoomTypeCommand, RoomTypeDTO>
    {
        public UpdateRoomTypeCommandHandler(IRoomTypeRepository roomTypeRepository)
        {
            RoomTypeRepository = roomTypeRepository;
        }

        public IRoomTypeRepository RoomTypeRepository { get; }

        public Task<RoomTypeDTO> Handle(UpdateRoomTypeCommand request, CancellationToken cancellationToken)
        {
            var result = RoomTypeRepository.Update(request.Id, request.UpdateRequest);

            return Task.FromResult(result);
        }
    }
}
