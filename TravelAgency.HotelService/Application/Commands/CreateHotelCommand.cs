using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Application.Commands
{
    public class CreateHotelCommand : IRequest<HotelDTO>
    {
        public HotelCreateRequest CreateRequest { get; }
        public CreateHotelCommand(HotelCreateRequest createRequest)
        {
            CreateRequest = createRequest;
        }

    }
}
