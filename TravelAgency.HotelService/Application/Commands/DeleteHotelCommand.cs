using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Application.Commands
{
    public class DeleteHotelCommand : IRequest<HotelDTO>
    {
        public object Id { get; }
        public DeleteHotelCommand(int id)
        {
            Id = id;
        }

    }
}
