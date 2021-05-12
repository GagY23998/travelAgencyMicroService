using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Application.Queries
{
    public class GetHotelOfferByIdQuery : IRequest<HotelOfferDTO>
    {
        public GetHotelOfferByIdQuery(object Id)
        {
            this.Id = Id;
        }

        public object Id { get; }
    }
}
