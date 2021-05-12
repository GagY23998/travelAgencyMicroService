using AutoMapper;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.TravelService.Application.Commands;
using TravelAgency.TravelService.Application.Commands.Handlers;
using TravelAgency.TravelService.Domain;
using TravelAgency.TravelService.Domain.Common;
using TravelAgency.TravelService.Domain.Common.Interfaces;
using TravelAgency.TravelService.Domain.DTOs;
using TravelAgency.TravelService.Infrastructure.Repositories;
using Xunit;
using Xunit.Sdk;

namespace UnitTesting.TravelService
{

    public class FakeDbConnection : IDbConnection
    {
        public string ConnectionString { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int ConnectionTimeout => throw new NotImplementedException();

        public string Database => throw new NotImplementedException();

        public ConnectionState State => throw new NotImplementedException();

        public IDbTransaction BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            throw new NotImplementedException();
        }

        public void ChangeDatabase(string databaseName)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public IDbCommand CreateCommand()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Open()
        {
            //Do nuthin
        }
    }

    public class CommandTests
    {

        Mock<IRepository<TransportCompany>> fakeTCompanyRepository;
        Mock<IRepository<TransportOffer>> fakeTOfferRepository;
        Mock<IRepository<TransportType>> fakeTTypeRepository;
        Mock<IRepository<City>> fakeCityRepository;
        Mock<IRepository<Tour>> fakeTourRepository;
        Mock<IRepository<Attraction>> fakeAttrRepository;
        Mock<IUnitOfWork> fakeUnitOfWork;
        Mock<ILogger<CreateTransportOfferCommandHandler>> fakeLogger;
        Mock<FakeDbConnection> fakeConnection;
        Mock<IConfiguration> fakeConfiguration;
        Mock<IMapper> fakeMapper;
        Mock<IDbSession> fakeDbSession;
        public CommandTests()
        {
            fakeTCompanyRepository = new Mock<IRepository<TransportCompany>>();
            fakeTTypeRepository = new Mock<IRepository<TransportType>>();
            fakeTOfferRepository = new Mock<IRepository<TransportOffer>>();
            fakeCityRepository = new Mock<IRepository<City>>();
            fakeAttrRepository = new Mock<IRepository<Attraction>>();
            fakeUnitOfWork = new Mock<IUnitOfWork>();
            fakeTourRepository = new Mock<IRepository<Tour>>();
            fakeConfiguration = new Mock<IConfiguration>();
            fakeDbSession = new Mock<IDbSession>();
            fakeMapper = new Mock<IMapper>();
            fakeConnection = new Mock<FakeDbConnection>();
            fakeConfiguration.SetupGet(x => x[It.Is<string>(s => s == "ConnectionStrings:default")]).Returns(It.IsAny<string>());
            fakeMapper.Setup(_ => _.Map<TransportCompany>(It.IsAny<TransportCompanyDTO>())).Returns(It.IsAny<TransportCompany>());
            fakeMapper.Setup(_ => _.Map<TransportCompanyDTO>(It.IsAny<TransportCompany>())).Returns(new TransportCompanyDTO());
            fakeUnitOfWork.SetupGet(_ => _.TCompanyRepository).Returns(fakeTCompanyRepository.Object);
            fakeUnitOfWork.SetupGet(_ => _.TOfferRepository).Returns(fakeTOfferRepository.Object);
            fakeUnitOfWork.SetupGet(_ => _.CityRepository).Returns(fakeCityRepository.Object);
            fakeUnitOfWork.SetupGet(_ => _.AttrRepository).Returns(fakeAttrRepository.Object);
            fakeUnitOfWork.SetupGet(_ => _.TTypeRepository).Returns(fakeTTypeRepository.Object);
            fakeUnitOfWork.SetupGet(_ => _.Connection).Returns(fakeConnection.Object);
            fakeUnitOfWork.SetupGet(_ => _.TourRepository).Returns(fakeTourRepository.Object);
        }

        [Fact]
        public async Task CreateTransports_IfValid_ReturnTour()
        {

            //Arrange
            TransportCompanyDTO createRequest = new TransportCompanyDTO();
            fakeTCompanyRepository.Setup(_ => _.InsertOneAsync(It.IsAny<DynamicParameters>(), It.IsAny<IDbTransaction>(),It.IsAny<string>())).Returns(Task.FromResult(new TransportCompany()));
            fakeTCompanyRepository.Setup(_ => _.GetTByIdAsync(It.IsAny<object>(), It.IsAny<IDbTransaction>(), It.IsAny<string>())).Returns(Task.FromResult(new TransportCompany()));
            CreateTransportCompanyCommand fakeCommand = new CreateTransportCompanyCommand(It.IsAny<TransportCompanyInsertRequest>());


            //Act
            CreateTransportCompanyCommandHandler fakeHandler = new CreateTransportCompanyCommandHandler(fakeMapper.Object, fakeDbSession.Object, fakeConfiguration.Object);
            var result = await fakeHandler.Handle(fakeCommand, new CancellationToken());

            //Assert
            Assert.IsType<int>(result);
        }
        [Fact]
        public async Task CreateAttractions_IfValid_ReturnTour()
        {

            //Arrange
            AttractionDTO createRequest = new AttractionDTO();
            fakeAttrRepository.Setup(_ => _.InsertOneAsync(It.IsAny<DynamicParameters>(), It.IsAny<IDbTransaction>(), It.IsAny<string>())).Returns(Task.FromResult(new Attraction()));
            fakeAttrRepository.Setup(_ => _.GetTByIdAsync(It.IsAny<object>(), It.IsAny<IDbTransaction>(), It.IsAny<string>())).Returns(Task.FromResult(new Attraction()));
            CreateAttractionCommand fakeCommand = new CreateAttractionCommand(It.IsAny<AttractionInsertRequest>());


            //Act
            CreateAttractionCommandHandler fakeHandler = new CreateAttractionCommandHandler(fakeMapper.Object, fakeDbSession.Object, fakeConfiguration.Object);
            var result = await fakeHandler.Handle(fakeCommand, new CancellationToken());
            //Assert
            Assert.IsType<int>(result);
        }
        [Fact]
        public async Task CreateTransportTypes_IfValid_ReturnTour()
        {

            //Arrange
            TransportTypeDTO createRequest = new TransportTypeDTO();
            fakeTTypeRepository.Setup(_ => _.InsertOneAsync(It.IsAny<DynamicParameters>(), It.IsAny<IDbTransaction>(), It.IsAny<string>())).Returns(Task.FromResult(new TransportType()));
            fakeTTypeRepository.Setup(_ => _.GetTByIdAsync(It.IsAny<object>(), It.IsAny<IDbTransaction>(), It.IsAny<string>())).Returns(Task.FromResult(new TransportType()));
            CreateTransportTypeCommand fakeCommand = new CreateTransportTypeCommand(It.IsAny<TransportTypeInsertRequest>());


            //Act
            CreateTransportTypeCommandHandler fakeHandler = new CreateTransportTypeCommandHandler(fakeMapper.Object, fakeDbSession.Object, fakeConfiguration.Object);
            var result = await fakeHandler.Handle(fakeCommand, new CancellationToken());
            //Assert
            Assert.IsType<int>(result);
        }

        [Fact]
        public async Task CreateTransportOfferss_IfValid_ReturnTour()
        {

            //Arrange
            TransportOfferDTO createRequest = new TransportOfferDTO();
            TransportOffer response = new TransportOffer();
            fakeTOfferRepository.Setup(_ => _.InsertOneAsync(It.IsAny<DynamicParameters>(), It.IsAny<IDbTransaction>(), It.IsAny<string>())).Returns(Task.FromResult(response));
            fakeTOfferRepository.Setup(_ => _.GetTByIdAsync(It.IsAny<object>(), It.IsAny<IDbTransaction>(), It.IsAny<string>())).Returns(Task.FromResult(response));
            CreateTransportOfferCommand fakeCommand = new CreateTransportOfferCommand(It.IsAny<TransportOfferInsertRequest>());


            //Act
            CreateTransportOfferCommandHandler fakeHandler = new CreateTransportOfferCommandHandler(fakeMapper.Object, fakeDbSession.Object, fakeConfiguration.Object,fakeLogger.Object);
            var result = await fakeHandler.Handle(fakeCommand, new CancellationToken());
            //Assert
            Assert.IsType<TransportOffer>(result);
            Assert.Same(response, result);
        }
        [Fact]
        public async Task CreateCities_IfValid_ReturnTour()
        {

            //Arrange
            CityDTO createRequest = new CityDTO();
            fakeCityRepository.Setup(_ => _.InsertOneAsync(It.IsAny<DynamicParameters>(), It.IsAny<IDbTransaction>(), It.IsAny<string>())).Returns(Task.FromResult(new City()));
            fakeCityRepository.Setup(_ => _.GetTByIdAsync(It.IsAny<object>(), It.IsAny<IDbTransaction>(), It.IsAny<string>())).Returns(Task.FromResult(new City()));
            CreateCityCommand fakeCommand = new CreateCityCommand(It.IsAny<CityInsertRequest>());


            //Act
            CreateCitiesCommandHandler fakeHandler = new CreateCitiesCommandHandler(fakeMapper.Object, fakeDbSession.Object, fakeConfiguration.Object);
            var result = await fakeHandler.Handle(fakeCommand, new CancellationToken());
            //Assert
            Assert.IsType<int>(result);
        }

        //[Fact]
        //public async Task CreateTour_IfValid_ReturnTour()
        //{
        //    //Arrange
        //    TourDTO createRequest = new TourDTO();
        //    Guid myguid = Guid.NewGuid();
        //    fakeTourRepository.Setup(_ => _.InsertOneAsync("", new { }, It.IsAny<IDbTransaction>())).Returns(Task.FromResult((object)myguid));
        //    fakeTourRepository.Setup(_ => _.GetTByIdAsync(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<IDbTransaction>())).Returns(Task.FromResult(new Tour()));
        //    CreateTourCommand fakeCommand = new CreateTourCommand("", new { });
        //    //Act
        //    CreateTourCommandHandler fakeHandler = new CreateTourCommandHandler(fakeMapper.Object, fakeUnitOfWork.Object, fakeConfiguration.Object);
        //    var result = await fakeHandler.Handle(fakeCommand, new CancellationToken());

        //    //Assert
        //    Assert.IsType<Guid>(result);
        //    Assert.Equal((Guid)result, myguid);

        //}

    }
}
