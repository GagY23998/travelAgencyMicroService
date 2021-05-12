using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Common;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Application.Queries
{
    public class GetRoomTypeByIdQueryHandler : IRequestHandler<GetRoomTypeByIdQuery, RoomTypeDTO>
    {
        public GetRoomTypeByIdQueryHandler(IRoomTypeRepository roomTypeRepository)
        {
            RoomTypeRepository = roomTypeRepository;
        }

        public IRoomTypeRepository RoomTypeRepository { get; }

        public Task<RoomTypeDTO> Handle(GetRoomTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var result = RoomTypeRepository.GetById(request.Id);
            return result != null ? Task.FromResult(result) : null;
        }
    }
}
