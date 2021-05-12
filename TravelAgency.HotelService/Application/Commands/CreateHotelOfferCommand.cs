using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Application.Commands
{
    public class CreateHotelOfferCommand : IRequest<HotelOfferDTO>
    {
        public CreateHotelOfferCommand(HotelOfferCreateRequest createRequest)
        {
            CreateRequest = createRequest;
        }

        public HotelOfferCreateRequest CreateRequest { get; }
    }
}
