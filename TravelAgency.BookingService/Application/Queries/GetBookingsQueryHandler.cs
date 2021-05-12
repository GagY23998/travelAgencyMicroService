using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.DTOs;
using TravelAgency.BookingService.Domain.Repositories;

namespace TravelAgency.BookingService.Application.Queries
{
    public class GetBookingsQueryHandler : IRequestHandler<GetBookingsQuery,IEnumerable<BookingDTO>>
    {
        private readonly IMediator mediator;
        private readonly IBookingRepository bookingRepository;
        private readonly IMapper mapper;

        public GetBookingsQueryHandler(IMediator mediator,IBookingRepository bookingRepository,IMapper mapper)
        {
            this.mediator = mediator;
            this.bookingRepository = bookingRepository;
            this.mapper = mapper;
        }
        public Task<IEnumerable<BookingDTO>> Handle(GetBookingsQuery request, CancellationToken cancellationToken)
        {
            var result = bookingRepository.getBooking(request.SearchRequest);
            var dtos = mapper.Map<IEnumerable<BookingDTO>>(result);
            return Task.FromResult<IEnumerable<BookingDTO>>(dtos);
        }
    }
}
