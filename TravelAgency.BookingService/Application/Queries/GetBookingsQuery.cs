using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.DTOs;

namespace TravelAgency.BookingService.Application.Queries
{
    public class GetBookingsQuery : IRequest<IEnumerable<BookingDTO>>
    {
        public BookingSearchRequest SearchRequest { get; set; }
        public GetBookingsQuery(BookingSearchRequest searchRequest)
        {
            SearchRequest = searchRequest;
        }
    }
}
