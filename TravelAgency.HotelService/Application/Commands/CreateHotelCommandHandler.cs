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
    public class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommand, HotelDTO>
    {
        public CreateHotelCommandHandler(IMediator mediator,IHotelRepository hotelRepository,IHotelRoomRepository hRoomRepository)
        {
            Mediator = mediator;
            HotelRepository = hotelRepository;
            HRoomRepository = hRoomRepository;
        }

        public IMediator Mediator { get; }
        public IHotelRepository HotelRepository { get; }
        public IHotelRoomRepository HRoomRepository { get; }

        public Task<HotelDTO> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
        {
            var hotelResult = HotelRepository.Add(request.CreateRequest);
            foreach (var item in request.CreateRequest.HotelRooms)
            {
              var result = HRoomRepository.Add(item);
                if (result == null) return null;
            }
            if(hotelResult != null)
            {
                return Task.FromResult(hotelResult);
            }
            return null;
        }
    }
}
