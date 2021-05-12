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
    public class DeleteHotelCommandHandler : IRequestHandler<DeleteHotelCommand, HotelDTO>
    {
        public IHotelRepository HotelRepository { get; }
        public IHotelRoomRepository HotelRoomRepository { get; }

        public DeleteHotelCommandHandler(IMediator mediator,IHotelRepository hotelRepository,IHotelRoomRepository hotelRoomRepository)
        {
            HotelRepository = hotelRepository;
            HotelRoomRepository = hotelRoomRepository;
        }


        public async Task<HotelDTO> Handle(DeleteHotelCommand request, CancellationToken cancellationToken)
        {
            HotelRoomSearchRequest searchRequest = new HotelRoomSearchRequest() { HotelId = (int)request.Id };
            var query = await HotelRoomRepository.Get(searchRequest);
            foreach (var item in query)
            {
                var res = HotelRoomRepository.Remove(item.Id);
            }
            var result = HotelRepository.Remove(request.Id);
            
            return result!=null?result: null;
        }
    }
}
