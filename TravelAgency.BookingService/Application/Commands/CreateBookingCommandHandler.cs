using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.Common;
using TravelAgency.BookingService.Domain.DTOs;
using TravelAgency.BookingService.Domain.Events;
using TravelAgency.BookingService.Domain.Repositories;
using TravelAgency.BookingService.Infrastructure;

namespace TravelAgency.BookingService.Application.Commands
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, BookingDTO>
    {
        private readonly IMediator mediator;
        private readonly IBookingRepository bookingRepository;
        private readonly IEventStoreRepository eventStoreRepository;
        private readonly IJsonSerializer serializer;

        //private readonly IMapper mapper;

        public CreateBookingCommandHandler(IMediator mediator, 
                                           IBookingRepository bookingRepository,
                                           IEventStoreRepository eventStoreRepository,
                                           IJsonSerializer serializer)
        {
            this.mediator = mediator;
            this.bookingRepository = bookingRepository;
            this.eventStoreRepository = eventStoreRepository;
            this.serializer = serializer;
            //this.mapper = mapper;
        }
        public Task<BookingDTO> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var result = bookingRepository.AddBooking(request.Booking);
        
            BookingCreatedEvent @event = new BookingCreatedEvent(1, result.HotelOffer, result.TransportOffer, result.ReservationDate, result.Payment, result.CanceledStatus);
            string payload = serializer.SerializeEvent<BookingCreatedEvent>(@event);
            if(result != null)
            {
                EventStore @eventStore = new EventStore(result.Id, 1, nameof(BookingCreatedEvent),payload,DateTime.Now);
                eventStoreRepository.AppendEvent(eventStore);
                return Task.FromResult(result);
            }
            return null;
        }
    }
}
