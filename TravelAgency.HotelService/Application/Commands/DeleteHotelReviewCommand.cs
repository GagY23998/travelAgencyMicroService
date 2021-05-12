using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Application.Commands
{
    public class DeleteHotelReviewCommand : IRequest<HotelReviewDTO>
    {
        public DeleteHotelReviewCommand(int hotelReviewId)
        {
            HotelReviewId = hotelReviewId;
        }

        public int HotelReviewId { get; }
    }
}
