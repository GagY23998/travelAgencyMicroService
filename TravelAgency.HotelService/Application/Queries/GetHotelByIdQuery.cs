using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Application.Queries
{
    public class GetHotelByIdQuery : IRequest<HotelDTO>
    {
        public object Id { get; }
       
        public GetHotelByIdQuery(object Id)
        {
            this.Id = Id;
        }

    }
}
