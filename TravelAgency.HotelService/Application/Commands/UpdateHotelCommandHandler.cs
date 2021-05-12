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
    public class UpdateHotelCommandHandler : IRequestHandler<UpdateHotelCommand, HotelDTO>
    {
        public UpdateHotelCommandHandler(IHotelRepository hotelRepository)
        {
            HotelRepository = hotelRepository;
        }

        public IHotelRepository HotelRepository { get; }

        public Task<HotelDTO> Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
        {
            HotelDTO hotel = HotelRepository.Update(request.Id, request.HotelCreateRequest);

            return Task.FromResult(hotel);
        }
    }
}
