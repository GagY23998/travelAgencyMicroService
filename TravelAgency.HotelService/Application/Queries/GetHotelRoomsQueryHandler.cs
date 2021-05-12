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
    public class GetHotelRoomsQueryHandler : IRequestHandler<GetHotelRoomsQuery, IEnumerable<HotelRoomDTO>>
    {
        public GetHotelRoomsQueryHandler(IHotelRoomRepository hotelRoomRepository)
        {
            HotelRoomRepository = hotelRoomRepository;
        }

        public IHotelRoomRepository HotelRoomRepository { get; }

        public async Task<IEnumerable<HotelRoomDTO>> Handle(GetHotelRoomsQuery request, CancellationToken cancellationToken)
        {
            var result = await HotelRoomRepository.Get(request.SearchRequest);

            return result != null ? result : null;
            
        }
    }
}
