using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.DTOs;
using TravelAgency.BookingService.Domain.Repositories;

namespace TravelAgency.BookingService.Application.Queries
{
    public class GetBookingByIdHandler : IRequestHandler<GetBookingByIdQuery, BookingDTO>
    {
        private readonly IMediator mediator;
        private readonly IBookingRepository bookingRepository;

        public GetBookingByIdHandler(IMediator mediator ,IBookingRepository bookingRepository)
        {
            this.mediator = mediator;
            this.bookingRepository = bookingRepository;
        }
        public Task<BookingDTO> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
        {
            var result = bookingRepository.getBookingById(request.ID);
            return Task.FromResult(result);
        }
    }
}
