using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Application.Queries
{
    public class GetHotelReviewsQuery : IRequest<IEnumerable<HotelReviewDTO>>
    {
        public GetHotelReviewsQuery(HotelReviewSearchRequest request)
        {
            Request = request;
        }

        public HotelReviewSearchRequest Request { get; }
    }
}
