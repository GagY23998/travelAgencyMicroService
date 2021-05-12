using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Routing.Matching;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.BookingService.Application.Commands;
using TravelAgency.BookingService.Application.Validators;
using TravelAgency.BookingService.Domain.BookingAggregate;
using TravelAgency.BookingService.Domain.DTOs;
using TravelAgency.BookingService.Domain.Repositories;
using TravelAgency.BookingService.Infrastructure;
using TravelAgency.BookingService.Infrastructure.Data;
using TravelAgency.BookingService.Infrastructure.Services;
using Xunit;

namespace UnitTesting.BookingService.Commands
{
    public class BookingCommandsTest
    {
        Mock<IMediator> _mediator;
        Mock<IBookingRepository> _bookingRepository;
        Mock<IMapper> _mapper;
        Mock<IEventStoreRepository> _mockEventStoreRepos;
        Mock<BookingDbContext> _context;
        Mock<IJsonSerializer> _mockSerializer;
            //Kreirati komandu
            //Setup
            //Napraviti validatore
            //ispunjava sve uslove valja
            //ne ispunjava ne valja 
        public BookingCommandsTest()
        {
            _context = new Mock<BookingDbContext>();
            _mediator = new Mock<IMediator>();
            _bookingRepository = new Mock<IBookingRepository>();
            _mapper = new Mock<IMapper>();
            _mockEventStoreRepos = new Mock<IEventStoreRepository>();
            _mockSerializer = new Mock<IJsonSerializer>();
        }


        [Fact]
        public async Task CreateBookingCommand_IfValid_ReturnTrue()
        {
            //Arrange
            _mediator.Setup(_ => _.Send(It.IsAny<CreateBookingCommand>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(new BookingDTO()));
            _bookingRepository.Setup(_ => _.AddBooking(It.IsAny<BookingCreateRequest>())).Returns(new BookingDTO());
            var fakeBooking = new CreateBookingCommand(It.IsAny<BookingCreateRequest>());
            //Act
            var cmdHandler = new CreateBookingCommandHandler(_mediator.Object,_bookingRepository.Object,_mockEventStoreRepos.Object,_mockSerializer.Object);
            _mediator.Verify(_ => _.Send(fakeBooking, default),Times.Never);
            var result= await cmdHandler.Handle(fakeBooking,new System.Threading.CancellationToken());
            //Assert
            Assert.IsType<BookingDTO>(result);           
        }
        [Fact]
        public async Task DeleteBookingCommand_IfValid_ReturnTrue()
        {
            //Arrange
            _mediator.Setup(_ => _.Send(It.IsAny<DeleteBookingCommand>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(true));
            _bookingRepository.Setup(_ => _.DeleteBooking(It.IsAny<Guid>())).Returns(true);
            var fakeBooking = new DeleteBookingCommand(Guid.NewGuid());
            //Act
            var handler = new DeleteBookingCommandHandler(_mediator.Object, _bookingRepository.Object);
            var result = await handler.Handle(fakeBooking, new CancellationToken());
            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task CancelBooking_IfValid_returnTrue()
        {
            //Arrange
            _mediator.Setup(_ => _.Send(It.IsAny<CancelBookingCommand>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(true));
            _bookingRepository.Setup(_ => _.CancelBooking(It.IsAny<Guid>())).Returns(true);
            _context.Setup(_ => _.Update(It.IsAny<Booking>()));
            var fakeBooking = new CancelBookingCommand(Guid.NewGuid());
            //Act
            var handler = new CancelBookingCommandHandler(_mediator.Object, _bookingRepository.Object);
            var result = await handler.Handle(fakeBooking, new CancellationToken());
            //Assert
            Assert.True(result);
        }
        [Fact]
        public async Task ChangeBookingHotelOffer_IfValid_ReturnTrue()
        {
            //Arrange
            _mediator.Setup(_ => _.Send(It.IsAny<ChangeBookingHotelOfferCommand>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(true));
            _context.Setup(_ => _.Find(typeof(Booking), It.IsAny<Guid>())).Returns(It.IsAny<Booking>());
            _context.Setup(_ => _.Update(It.IsAny<Booking>()));
            _bookingRepository.Setup(_ => _.ChangeHotelOfferBooking(It.IsAny<Guid>())).Returns(new BookingDTO());
            var fakeBooking = new ChangeBookingHotelOfferCommand(Guid.NewGuid());
            //Act
            var handler = new ChangeBookingHotelOfferCommandHandler(_mediator.Object, _bookingRepository.Object);
            var result = await handler.Handle(fakeBooking, new CancellationToken());
            //Assert
            Assert.True(result);
        }
        [Fact]
        public async Task ChangeBookingTourOffer_IfValid_ReturnTrue()
        {
            //Arrange
            _mediator.Setup(_ => _.Send(It.IsAny<ChangeBookingTourOfferCommand>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(true));
            //_bookingRepository.Setup(_ => _.ChangeTourOfferBooking(It.IsAny<Guid>())).Returns(new BookingDTO());
            _context.Setup(_ => _.Find(typeof(Booking), It.IsAny<Guid>())).Returns(It.IsAny<Booking>());
            _context.Setup(_ => _.Update(It.IsAny<Booking>()));
            var fakeBooking = new ChangeBookingTourOfferCommand(Guid.NewGuid());
            //Act
            var handler = new ChangeBookingTourOfferCommandHandler(_mediator.Object, _bookingRepository.Object);
            var result = await handler.Handle(fakeBooking, new CancellationToken());
            //Assert
            Assert.True(result);
        }
        [Fact]
        public async Task ChangeBookingTransportOffer_IfValid_ReturnTrue()
        {
            //Arrange
            _mediator.Setup(_ => _.Send(It.IsAny<ChangeBookingTransportOfferCommand>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(true));
            _context.Setup(_ => _.Find(typeof(Booking), It.IsAny<Guid>())).Returns(It.IsAny<Booking>());
            _context.Setup(_ => _.Update(It.IsAny<Booking>()));
            _bookingRepository.Setup(_ => _.ChangeTransportOfferBooking(It.IsAny<Guid>())).Returns(new BookingDTO());
            var fakeBooking = new ChangeBookingTransportOfferCommand(Guid.NewGuid());
            //Act
            var handler = new ChangeBookingTransportOfferCommandHandler(_mediator.Object, _bookingRepository.Object);
            var result = await handler.Handle(fakeBooking, new CancellationToken());
            //Assert
            Assert.True(result);
        }
        [Fact]
        public async Task UpdateBooking_IfValid_ReturnTrue()
        {
            //Arrange
            _mediator.Setup(_ => _.Send(It.IsAny<UpdateBookingCommand>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(new BookingDTO()));
            _bookingRepository.Setup(_ => _.UpdateBooking(It.IsAny<Guid>(),It.IsAny<BookingCreateRequest>())).Returns(new BookingDTO());
            var fakeBooking = new UpdateBookingCommand(Guid.NewGuid(),new BookingCreateRequest());
            //Act
            var handler = new UpdateBookingCommandHandler(_mediator.Object, _bookingRepository.Object);
            var result = await handler.Handle(fakeBooking, new CancellationToken());
            //Assert
            Assert.NotNull(result);
        }
    }
}
