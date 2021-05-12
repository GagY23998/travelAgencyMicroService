using AutoMapper;
using MassTransit;
using MediatR;
using MessageBroker.Consumers.Contracts;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.HotelService.Application.Queries;
using TravelAgency.HotelService.Domain.Common;
using TravelAgency.HotelService.Domain.Common.Interfaces;
using TravelAgency.HotelService.Domain.Models;
using Xunit;

namespace UnitTesting.HotelService
{
    public class QueryTests
    {

        Mock<IHotelRepository> fakeHotelRepository;
        Mock<IRoomTypeRepository> fakeRoomTypeRepository;
        Mock<IHotelRoomRepository> fakeHotelRoomRepository;
        Mock<IHotelOfferRepository> fakeHotelOfferRepository;
        Mock<IRequestClient<GetUser>> fakeRequestClient;
        Mock<ILogger<GetHotelsQueryHandler>> fakeLogger;
        Mock<IMediator> fakeMediator;
        Mock<IMapper> fakeMapper;
        Mock<IBus> fakeBus;
        public QueryTests()
        {
            fakeHotelRepository = new Mock<IHotelRepository>();
            fakeHotelRoomRepository = new Mock<IHotelRoomRepository>();
            fakeHotelOfferRepository = new Mock<IHotelOfferRepository>();
            fakeRoomTypeRepository = new Mock<IRoomTypeRepository>();
            fakeMapper = new Mock<IMapper>();
            fakeMediator = new Mock<IMediator>();
            fakeLogger = new Mock<ILogger<GetHotelsQueryHandler>>();
            fakeBus = new Mock<IBus>();
        }

        [Fact]
        public async Task GetHotels_ReturnList()
        {

            //Arrange
            fakeHotelRepository.Setup(_ => _.Get(It.IsAny<HotelSearchRequest>())).Returns(Task.FromResult(new List<HotelDTO>() { new HotelDTO() }.AsEnumerable()));
            GetHotelsQuery fakeCommand = new GetHotelsQuery(It.IsAny<HotelSearchRequest>());


            //Act
            GetHotelsQueryHandler fakeCommandHandler = new GetHotelsQueryHandler(fakeMediator.Object,fakeMapper.Object, fakeHotelRepository.Object,fakeBus.Object,fakeLogger.Object);

            var result = await fakeCommandHandler.Handle(fakeCommand, new System.Threading.CancellationToken());

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task GetHotelById_ReturnHotel()
        {
            //Arrange
            fakeHotelRepository.Setup(_ => _.GetById(It.IsAny<int>())).Returns(new HotelDTO());
            GetHotelByIdQuery fakeCommand = new GetHotelByIdQuery(It.IsAny<int>());

            //Act
            GetHotelByIdQueryHandler fakeCommandHandler = new GetHotelByIdQueryHandler(fakeHotelRepository.Object);

            var result = await fakeCommandHandler.Handle(fakeCommand, new System.Threading.CancellationToken());

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetHotelRooms_ReturnList()
        {

            //Arrange
            fakeHotelRoomRepository.Setup(_ => _.Get(It.IsAny<HotelRoomSearchRequest>())).Returns(Task.FromResult(new List<HotelRoomDTO>() { new HotelRoomDTO() }.AsEnumerable()));
            GetHotelRoomsQuery fakeCommand = new GetHotelRoomsQuery(It.IsAny<HotelRoomSearchRequest>());


            //Act
            GetHotelRoomsQueryHandler fakeCommandHandler = new GetHotelRoomsQueryHandler(fakeHotelRoomRepository.Object);

            var result = await fakeCommandHandler.Handle(fakeCommand, new System.Threading.CancellationToken());

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task GetHotelRoomById_ReturnHotel()
        {
            //Arrange
            fakeHotelRoomRepository.Setup(_ => _.GetById(It.IsAny<int>())).Returns(new HotelRoomDTO());
            GetHotelRoomByIdQuery fakeCommand = new GetHotelRoomByIdQuery(It.IsAny<int>());

            //Act
            GetHotelRoomByIdQueryHandler fakeCommandHandler = new GetHotelRoomByIdQueryHandler(fakeHotelRoomRepository.Object);

            var result = await fakeCommandHandler.Handle(fakeCommand, new System.Threading.CancellationToken());

            //Assert
            Assert.NotNull(result);
        }
        [Fact]

        public async Task GetRoomtypesQuery_ReturnList()
        {
            //Arrange

            fakeRoomTypeRepository.Setup(_ => _.Get(It.IsAny<RoomTypeSearchRequest>())).Returns(Task.FromResult(new List<RoomTypeDTO>() { new RoomTypeDTO() }.AsEnumerable()));
            GetRoomTypesQuery fakeQuery = new GetRoomTypesQuery(It.IsAny<RoomTypeSearchRequest>());

            //Act
            GetRoomTypesQueryHandler fakeHandler = new GetRoomTypesQueryHandler(fakeRoomTypeRepository.Object);
            var result = await fakeHandler.Handle(fakeQuery, new CancellationToken());
            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);

        }
        [Fact]
        public async Task GetRoomTypeById_ReturnHotel()
        {
            //Arrange
            fakeRoomTypeRepository.Setup(_ => _.GetById(It.IsAny<int>())).Returns(new RoomTypeDTO());
            GetRoomTypeByIdQuery fakeCommand = new GetRoomTypeByIdQuery(It.IsAny<int>());

            //Act
            GetRoomTypeByIdQueryHandler fakeCommandHandler = new GetRoomTypeByIdQueryHandler(fakeRoomTypeRepository.Object);

            var result = await fakeCommandHandler.Handle(fakeCommand, new System.Threading.CancellationToken());

            //Assert
            Assert.NotNull(result);
        }
        [Fact]
        public async Task GetHotelOfferQuery_ReturnList()
        {
            //Arrange

            fakeHotelOfferRepository.Setup(_ => _.Get(It.IsAny<HotelOfferSearchRequest>())).Returns(Task.FromResult(new List<HotelOfferDTO>() { new HotelOfferDTO() }.AsEnumerable()));
            GetHotelOffersQuery fakeQuery = new GetHotelOffersQuery(It.IsAny<HotelOfferSearchRequest>());

            //Act
            GetHotelOffersQueryHandler fakeHandler = new GetHotelOffersQueryHandler(fakeHotelOfferRepository.Object);
            var result = await fakeHandler.Handle(fakeQuery, new CancellationToken());
            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);

        }
        //[Fact]
        //public async Task GetHotelOfferById_ReturnHotelOffer()
        //{
        //    //Arrange
        //    fakeRoomTypeRepository.Setup(_ => _.GetById(It.IsAny<int>())).Returns(new RoomTypeDTO());
        //    GetRoomtypeByIdQuery fakeCommand = new GetRoomTypeByIdQuery(It.IsAny<int>());

        //    //Act
        //    GetRoomTypeByIdQueryHandler fakeCommandHandler = new GetRoomTypeByIdQueryHandler(fakeRoomTypeRepository.Object);

        //    var result = await fakeCommandHandler.Handle(fakeCommand, new System.Threading.CancellationToken());

        //    //Assert
        //    Assert.NotNull(result);
        //}
    }
}
