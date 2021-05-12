using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Application.Commands
{
    public class DeleteHotelOfferCommand : IRequest<HotelOfferDTO>
    {
        public DeleteHotelOfferCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
