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
    public class DeleteRoomTypeCommandHandler : IRequestHandler<DeleteRoomTypeCommand, RoomTypeDTO>
    {
        public IMediator Mediator { get; }
        public IRoomTypeRepository RoomTypeRepository { get; }
        
        public DeleteRoomTypeCommandHandler(IMediator mediator, IRoomTypeRepository roomTypeRepository)
        {
            Mediator = mediator;
            RoomTypeRepository = roomTypeRepository;
        }


        public Task<RoomTypeDTO> Handle(DeleteRoomTypeCommand request, CancellationToken cancellationToken)
        {
            var result = RoomTypeRepository.Remove(request.Id);

            return result != null ? Task.FromResult(result) : null;
        }
    }
}
