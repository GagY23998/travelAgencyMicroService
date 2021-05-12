using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain.Models;

namespace TravelAgency.HotelService.Application.Commands
{
    public class CreateHotelReviewCommand : IRequest<HotelReviewDTO>
    {
        public CreateHotelReviewCommand(HotelReviewInsertRequest insertRequest)
        {
            InsertRequest = insertRequest;
        }

        public HotelReviewInsertRequest InsertRequest { get; }
    }
}
