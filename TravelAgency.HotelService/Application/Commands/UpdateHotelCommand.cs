using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Application.Commands
{
    public class UpdateHotelCommand : IRequest<HotelDTO>
    {
        public UpdateHotelCommand(object id, HotelCreateRequest hotelCreateRequest)
        {
            Id = id;
            HotelCreateRequest = hotelCreateRequest;
        }

        public object Id { get; }
        public HotelCreateRequest HotelCreateRequest { get; }
    }
}
