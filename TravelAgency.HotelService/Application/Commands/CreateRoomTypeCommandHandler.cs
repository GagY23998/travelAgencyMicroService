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
    public class CreateRoomTypeCommandHandler : IRequestHandler<CreateRoomTypeCommand, RoomTypeDTO>
    {
        public IMediator Mediator { get; }
        public IRoomTypeRepository RoomTypeRepository { get; }

        public CreateRoomTypeCommandHandler(IMediator mediator, IRoomTypeRepository roomTypeRepository)
        {
            Mediator = mediator;
            RoomTypeRepository = roomTypeRepository;
        }
        public Task<RoomTypeDTO> Handle(CreateRoomTypeCommand request, CancellationToken cancellationToken)
        {
            var result = RoomTypeRepository.Add(request.CreateRequest);

            return result != null ? Task.FromResult(result) : null;
        }
    }
}
