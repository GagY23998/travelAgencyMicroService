using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Application.Commands
{
    public class UpdateHotelOfferCommand : IRequest<HotelOfferDTO>
    {
        public UpdateHotelOfferCommand(object Id, HotelOfferCreateRequest updateRequest)
        {
            this.Id = Id;
            UpdateRequest = updateRequest;
        }

        public object Id { get; }
        public HotelOfferCreateRequest UpdateRequest { get; }
    }
}
