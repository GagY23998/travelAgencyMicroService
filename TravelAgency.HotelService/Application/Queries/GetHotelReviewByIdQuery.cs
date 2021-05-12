using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Application.Queries
{
    public class GetHotelReviewByIdQuery : IRequest<HotelReviewDTO>
    {
        public int Id { get; set; }
        public GetHotelReviewByIdQuery(int id)
        {
            Id = id;
        }
    }
}
