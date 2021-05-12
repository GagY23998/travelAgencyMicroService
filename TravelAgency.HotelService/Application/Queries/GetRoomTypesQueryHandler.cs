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
    public class GetRoomTypesQueryHandler : IRequestHandler<GetRoomTypesQuery, IEnumerable<RoomTypeDTO>>
    {
        public GetRoomTypesQueryHandler(IRoomTypeRepository roomTypeRepository)
        {
            RoomTypeRepository = roomTypeRepository;
        }

        public IRoomTypeRepository RoomTypeRepository { get; }

        public async Task<IEnumerable<RoomTypeDTO>> Handle(GetRoomTypesQuery request, CancellationToken cancellationToken)
        {
            var result = await RoomTypeRepository.Get(request.SearchRequest);


            return result != null ? result : null;
        }
    }
}
