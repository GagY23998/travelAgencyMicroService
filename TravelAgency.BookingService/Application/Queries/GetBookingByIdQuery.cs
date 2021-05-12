using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.DTOs;

namespace TravelAgency.BookingService.Application.Queries
{
    public class GetBookingByIdQuery : IRequest<BookingDTO>
    {
        public Guid ID { get; set; }

        public GetBookingByIdQuery(Guid ID)
        {
            this.ID = ID;
        }
    }
}
