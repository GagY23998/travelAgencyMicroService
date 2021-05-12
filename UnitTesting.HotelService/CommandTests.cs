using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Application.Commands;
using TravelAgency.HotelService.Domain;
using TravelAgency.HotelService.Domain.Common;
using TravelAgency.HotelService.Domain.Common.Interfaces;
using TravelAgency.HotelService.Domain.Models;
using Xunit;

namespace UnitTesting.HotelService
{
    public class CommandTests
    {
        Mock<IHotelRepository> fakeHotelRepository;
        Mock<IHotelOfferRepository> fakeHotelOfferRepository;
        Mock<IHotelRoomRepository> fakeHotelRoomRepository;
        Mock<IRoomTypeRepository> fakeRoomTypeRepository;
        Mock<IMediator> mockMediator;
        public CommandTests()
        {
            fakeHotelRepository = new Mock<IHotelRepository>();
            fakeHotelOfferRepository = new Mock<IHotelOfferRepository>();
            fakeHotelRoomRepository = new Mock<IHotelRoomRepository>();
            fakeRoomTypeRepository = new Mock<IRoomTypeRepository>();
            mockMediator = new Mock<IMediator>();
        }

        [Fact]
        public async Task CreateHotel_IfValid_ReturnTrue()
        {

            //Arrange
            CreateHotelCommand fakeCommand = new CreateHotelCommand(It.IsAny<HotelCreateRequest>());
            mockMediator.Setup(_ => _.Send(fakeCommand, new System.Threading.CancellationToken())).Returns(Task.FromResult(new HotelDTO()));
            fakeHotelRepository.Setup(_ => _.Add(It.IsAny<HotelCreateRequest>())).Returns(new HotelDTO());

            CreateHotelCommandHandler fakeHandler = new CreateHotelCommandHandler(mockMediator.Object, fakeHotelRepository.Object, fakeHotelRoomRepository.Object);

            //Act
            var result = await fakeHandler.Handle(fakeCommand, new System.Threading.CancellationToken());

            //Assert
            Assert.IsType<HotelDTO>(result);
        }
        [Fact]
        public async Task DeleteHotel_IfValid_ReturnTrue()
        {

            //Arrange
            DeleteHotelCommand fakeCommand = new DeleteHotelCommand(It.IsAny<int>());
            mockMediator.Setup(_ => _.Send(fakeCommand, new System.Threading.CancellationToken())).Returns(Task.FromResult(new HotelDTO()));
            fakeHotelRoomRepository.Setup(_ => _.Get(It.IsAny<HotelRoomSearchRequest>())).Returns(Task.FromResult(new List<HotelRoomDTO>().AsEnumerable()));
            fakeHotelRoomRepository.Setup(_ => _.Remove(It.IsAny<int>())).Returns(new HotelRoomDTO());
            fakeHotelRepository.Setup(_ => _.Remove(It.IsAny<int>())).Returns(new HotelDTO());
            fakeHotelRepository.Setup(_ => _.Add(It.IsAny<HotelCreateRequest>())).Returns(new HotelDTO());

            DeleteHotelCommandHandler fakeHandler = new DeleteHotelCommandHandler(mockMediator.Object, fakeHotelRepository.Object, fakeHotelRoomRepository.Object);

            //Act
            var result = await fakeHandler.Handle(fakeCommand, new System.Threading.CancellationToken());

            //Assert
            Assert.IsType<HotelDTO>(result);
        }
        [Fact]
        public async Task CreateHotelOffer_If_Valid_ReturnTrue()
        {
            //Arrange
            CreateHotelOfferCommand fakeCommand = new CreateHotelOfferCommand(It.IsAny<HotelOfferCreateRequest>());
            fakeHotelOfferRepository.Setup(_ => _.Add(It.IsAny<HotelOfferCreateRequest>())).Returns(new HotelOfferDTO());

            CreateHotelOfferCommandHandler fakeHandler = new CreateHotelOfferCommandHandler(mockMediator.Object, fakeHotelOfferRepository.Object);

            //Act
            var result = await fakeHandler.Handle(fakeCommand, new System.Threading.CancellationToken());

            //Assert
            Assert.IsType<HotelOfferDTO>(result);
        }
        [Fact]
        public async Task DeleteHotelOffer_If_Valid_ReturnTrue()
        {
            //Arrange
            DeleteHotelOfferCommand fakeCommand = new DeleteHotelOfferCommand(It.IsAny<int>());
            fakeHotelOfferRepository.Setup(_ => _.Remove(It.IsAny<int>())).Returns(new HotelOfferDTO());

            DeleteHotelOfferCommandHandler fakeHandler = new DeleteHotelOfferCommandHandler(mockMediator.Object, fakeHotelOfferRepository.Object);

            //Act
            var result = await fakeHandler.Handle(fakeCommand, new System.Threading.CancellationToken());

            //Assert
            Assert.IsType<HotelOfferDTO>(result);
        }
        [Fact]
        public async Task CreateRoomType_If_Valid_ReturnTrue()
        {
            //Arrange
            CreateRoomTypeCommand fakeCommand = new CreateRoomTypeCommand(It.IsAny<RoomTypeCreateRequest>());
            fakeRoomTypeRepository.Setup(_ => _.Add(It.IsAny<RoomTypeCreateRequest>())).Returns(new RoomTypeDTO());

            CreateRoomTypeCommandHandler fakeHandler = new CreateRoomTypeCommandHandler(mockMediator.Object, fakeRoomTypeRepository.Object);

            //Act
            var result = await fakeHandler.Handle(fakeCommand, new System.Threading.CancellationToken());

            //Assert
            Assert.IsType<RoomTypeDTO>(result);
        }
        [Fact]
        public async Task DeleteRoomType_If_Valid_ReturnTrue()
        {
            //Arrange
            DeleteRoomTypeCommand fakeCommand = new DeleteRoomTypeCommand(It.IsAny<int>());
            fakeRoomTypeRepository.Setup(_ => _.Remove(It.IsAny<int>())).Returns(new RoomTypeDTO());

            DeleteRoomTypeCommandHandler fakeHandler = new DeleteRoomTypeCommandHandler(mockMediator.Object, fakeRoomTypeRepository.Object);

            //Act
            var result = await fakeHandler.Handle(fakeCommand, new System.Threading.CancellationToken());

            //Assert
            Assert.IsType<RoomTypeDTO>(result);
        }
    }
}
