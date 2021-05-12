using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Application.Commands
{
    public class UpdateHotelReviewCommand : IRequest<HotelReviewDTO>
    {
        public UpdateHotelReviewCommand(int id, HotelReviewInsertRequest updateRequest)
        {
            Id = id;
            UpdateRequest = updateRequest;
        }

        public int Id { get; }
        public HotelReviewInsertRequest UpdateRequest { get; }
    }
}
