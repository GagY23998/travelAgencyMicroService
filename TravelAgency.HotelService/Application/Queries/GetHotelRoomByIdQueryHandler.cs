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
    public class GetHotelRoomByIdQueryHandler : IRequestHandler<GetHotelRoomByIdQuery, HotelRoomDTO>
    {
        public GetHotelRoomByIdQueryHandler(IHotelRoomRepository hotelRoomRepository)
        {
            HotelRoomRepository = hotelRoomRepository;
        }

        public IHotelRoomRepository HotelRoomRepository { get; }

        public Task<HotelRoomDTO> Handle(GetHotelRoomByIdQuery request, CancellationToken cancellationToken)
        {
            var result = HotelRoomRepository.GetById(request.Id);

            return result != null ? Task.FromResult(result) : null;
        }
    }
}
