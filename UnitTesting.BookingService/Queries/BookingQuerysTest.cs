using AutoMapper;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.BookingService.Application.Queries;
using TravelAgency.BookingService.Domain.BookingAggregate;
using TravelAgency.BookingService.Domain.DTOs;
using TravelAgency.BookingService.Domain.Repositories;
using Xunit;

namespace UnitTesting.BookingService.Queries
{
    public class BookingQuerysTest
    {

        Mock<IBookingRepository> mockRepository;
        Mock<IMediator> mediator;
        Mock<IMapper> mapper;
        public BookingQuerysTest()
        {
            mockRepository = new Mock<IBookingRepository>();
            mediator = new Mock<IMediator>();
            mapper = new Mock<IMapper>();
        }


        [Fact]
        public async Task GetBookingById_IfSuccess_returnBooking()
        {
            //Arrange
            mapper.Setup(_ => _.Map<BookingDTO>(new Booking())).Returns(new BookingDTO());
            mediator.Setup(_ => _.Send(It.IsAny<GetBookingByIdQuery>(), new CancellationToken())).Returns(Task.FromResult(new BookingDTO()));
            mockRepository.Setup(_ => _.getBookingById(It.IsAny<Guid>())).Returns(new BookingDTO());
            GetBookingByIdQuery fakeQuery = new GetBookingByIdQuery(It.IsAny<Guid>());
            //Act
            GetBookingByIdHandler fakeHandler = new GetBookingByIdHandler(mediator.Object, mockRepository.Object);
            var result = await fakeHandler.Handle(fakeQuery, new CancellationToken());
            //Assert
            Assert.NotNull(result);
        }
        [Fact]
        public async Task GetBooking_IfSuccess_ReturnBookings()
        {
            //Arrange
            mapper.Setup(_ => _.Map<IEnumerable<BookingDTO>>(new List<Booking>())).Returns(new List<BookingDTO>());
            mediator.Setup(_ => _.Send(It.IsAny<GetBookingsQuery>(), new CancellationToken())).Returns(Task.FromResult(It.IsAny<IEnumerable<BookingDTO>>()));
            mockRepository.Setup(_ => _.getBookingById(It.IsAny<Guid>())).Returns(new BookingDTO());
            GetBookingsQuery fakeQuery = new GetBookingsQuery(It.IsAny<BookingSearchRequest>());
            //Act
            GetBookingsQueryHandler fakeHandler = new GetBookingsQueryHandler(mediator.Object, mockRepository.Object,mapper.Object);
            var result = await fakeHandler.Handle(fakeQuery, new CancellationToken());
            //Assert
            Assert.NotNull(result);
        }
    }
}
