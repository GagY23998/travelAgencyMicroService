using Microsoft.Extensions.Configuration;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TravelAgency.TravelService.Domain;
using TravelAgency.TravelService.Domain.Common;
using Xunit;
using TravelAgency.TravelService.Domain.DTOs;
using TravelAgency.TravelService.Application.Queries;
using TravelAgency.TravelService.Application.Queries.Handlers;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using System.Linq;
using Dapper;
using TravelAgency.TravelService.Domain.Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace UnitTesting.TravelService
{
    public class FakeTransaction : IDbTransaction
    {
        public IDbConnection Connection => throw new NotImplementedException();

        public IsolationLevel IsolationLevel => throw new NotImplementedException();

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
    public class QueryTests
    {

        Mock<IRepository<TransportCompany>> fakeTCompanyRepository;
        Mock<IRepository<TransportOffer>> fakeTOfferRepository;
        Mock<IRepository<TransportType>> fakeTTypeRepository;
        Mock<IRepository<City>> fakeCityRepository;
        Mock<IRepository<Attraction>> fakeAttrRepository;
        Mock<IUnitOfWork> fakeUnitOfWork;
        Mock<FakeDbConnection> fakeConnection;
        private Mock<ILogger<GetTransportOfferQueryHandler>> fakeLogger;
        Mock<IConfiguration> fakeConfiguration;
        Mock<IMapper> fakeMapper;
        Mock<IDbSession> fakeDbSession;
        public QueryTests()
        {
            fakeTCompanyRepository = new Mock<IRepository<TransportCompany>>();
            fakeTTypeRepository = new Mock<IRepository<TransportType>>();
            fakeTOfferRepository = new Mock<IRepository<TransportOffer>>();
            fakeCityRepository = new Mock<IRepository<City>>();
            fakeAttrRepository = new Mock<IRepository<Attraction>>();
            fakeUnitOfWork = new Mock<IUnitOfWork>();
            fakeConfiguration = new Mock<IConfiguration>();
            fakeMapper = new Mock<IMapper>();
            fakeConnection = new Mock<FakeDbConnection>();
            fakeLogger = new Mock<ILogger<GetTransportOfferQueryHandler>>();
            fakeConfiguration.SetupGet(x => x[It.Is<string>(s => s == "ConnectionStrings:default")]).Returns(It.IsAny<string>());
            fakeMapper.Setup(_ => _.Map<TransportCompany>(It.IsAny<TransportCompanyDTO>())).Returns(It.IsAny<TransportCompany>());
            fakeMapper.Setup(_ => _.Map<TransportCompanyDTO>(It.IsAny<TransportCompany>())).Returns(new TransportCompanyDTO());
            fakeMapper.Setup(_ => _.Map<TransportOfferDTO>(It.IsAny<TransportOffer>())).Returns(new TransportOfferDTO());
            fakeMapper.Setup(_ => _.Map<TransportOffer>(It.IsAny<TransportOfferDTO>())).Returns(It.IsAny<TransportOffer>());
            fakeMapper.Setup(_ => _.Map<TransportTypeDTO>(It.IsAny<TransportType>())).Returns(new TransportTypeDTO());
            fakeMapper.Setup(_ => _.Map<TransportType>(It.IsAny<TransportTypeDTO>())).Returns(new TransportType());
            fakeMapper.Setup(_ => _.Map<City>(It.IsAny<CityDTO>())).Returns(new City());
            fakeMapper.Setup(_ => _.Map<CityDTO>(It.IsAny<City>())).Returns(new CityDTO());
            fakeMapper.Setup(_ => _.Map<Attraction>(It.IsAny<AttractionDTO>())).Returns(new Attraction());
            fakeMapper.Setup(_ => _.Map<AttractionDTO>(It.IsAny<Attraction>())).Returns(new AttractionDTO());
            fakeUnitOfWork.SetupGet(_ => _.TCompanyRepository).Returns(fakeTCompanyRepository.Object);
            fakeUnitOfWork.SetupGet(_ => _.TOfferRepository).Returns(fakeTOfferRepository.Object);
            fakeUnitOfWork.SetupGet(_ => _.TTypeRepository).Returns(fakeTTypeRepository.Object);
            fakeUnitOfWork.SetupGet(_ => _.CityRepository).Returns(fakeCityRepository.Object);
            fakeUnitOfWork.SetupGet(_ => _.AttrRepository).Returns(fakeAttrRepository.Object);
            fakeUnitOfWork.SetupGet(_ => _.Connection).Returns(fakeConnection.Object);
            fakeUnitOfWork.SetupGet(_ => _.Transaction).Returns(new FakeTransaction());
        }
        [Fact]

        public async Task GetTransports_ReturnTours()
        {

            //Arrange
            var fakeList = new List<TransportCompany>() { new TransportCompany() { Id = 1 } }.AsEnumerable();
            var fakeDTOlist = new List<TransportCompanyDTO>() { new TransportCompanyDTO() { Id = 1 } }.AsEnumerable();
            fakeTCompanyRepository.Setup(_ => _.GetTAsync(It.IsAny<DynamicParameters>(),It.IsAny<IDbTransaction>(),It.IsAny<string>())).Returns(Task.FromResult(fakeList));
            fakeMapper.Setup(_ => _.Map<IEnumerable<TransportCompanyDTO>>(It.IsAny<IEnumerable<TransportCompany>>())).Returns(fakeDTOlist);
            GetTransportCompaniesQuery fakeQuery = new GetTransportCompaniesQuery(It.IsAny<TransportCompanySearchRequest>());
            //Act
            GetTransportCompaniesQueryHandler fakeHandler = new GetTransportCompaniesQueryHandler(fakeMapper.Object,
                                                                                                  fakeUnitOfWork.Object,
                                                                                                  fakeTCompanyRepository.Object,
                                                                                                  fakeConfiguration.Object);

            var result = await fakeHandler.Handle(fakeQuery, new CancellationToken());
            //Assert
            Assert.IsType<List<TransportCompanyDTO>>(result);
        }
        [Fact]
        public async Task GetTransportById_ReturnTour()
        {
            //Arrange
            var fakeTour = new TransportCompany();
            fakeTCompanyRepository.Setup(_ => _.GetTByIdAsync(It.IsAny<DynamicParameters>(), It.IsAny<IDbTransaction>(), It.IsAny<string>())).Returns(Task.FromResult(fakeTour));

            GetTransportCompanyByIdQuery fakeQuery = new GetTransportCompanyByIdQuery(It.IsAny<object>());

            //Act
            GetTransportCompanyByIdQueryHandler fakeHandler = new GetTransportCompanyByIdQueryHandler(fakeMapper.Object, fakeDbSession.Object);
            var result = await fakeHandler.Handle(fakeQuery, new CancellationToken());
            //Assert
            Assert.IsType<TransportCompanyDTO>(result);
        }

        [Fact]
        public async Task GetTransportOffers_ReturnOffers()
        {

            //Arrange
            var fakeTransaction = new Mock<FakeTransaction>();
            Guid fakeID = Guid.NewGuid();
            var fakeList = new List<TransportOffer>() { new TransportOffer() { Id = fakeID } }.AsEnumerable();
            var fakeDTOlist = new List<TransportOfferDTO>() { new TransportOfferDTO() { Id = fakeID } }.AsEnumerable();
            fakeTOfferRepository.Setup(_ => _.GetTAsync(It.IsAny<DynamicParameters>(), It.IsAny<IDbTransaction>(), It.IsAny<string>())).Returns(Task.FromResult(fakeList));
            fakeUnitOfWork.SetupGet(_ => _.Transaction).Returns(fakeTransaction.Object);
            fakeTOfferRepository.SetupGet(_ => _.Connection).Returns(fakeConnection.Object);
            fakeMapper.Setup(_ => _.Map<IEnumerable<TransportOfferDTO>>(It.IsAny<IEnumerable<TransportOffer>>())).Returns(fakeDTOlist);
            GetTransportOfferQuery fakeQuery = new GetTransportOfferQuery(It.IsAny<TransportOfferSearchRequest>());
            //Act
            GetTransportOfferQueryHandler fakeHandler = new GetTransportOfferQueryHandler(fakeMapper.Object,fakeUnitOfWork.Object,fakeConfiguration.Object,fakeLogger.Object);

            var result = await fakeHandler.Handle(fakeQuery, new CancellationToken());
            //Assert
            Assert.IsType<List<TransportOfferDTO>>(result);


        }

        [Fact]
        public async Task GetTransportOfferById_ReturnTransportOffer()
        {
            //Arrange
            var fakeTour = new TransportOffer();
            fakeTOfferRepository.Setup(_ => _.GetTByIdAsync(It.IsAny<DynamicParameters>(), It.IsAny<IDbTransaction>(), It.IsAny<string>())).Returns(Task.FromResult(fakeTour));

            GetTransportOfferByIdQuery fakeQuery = new GetTransportOfferByIdQuery(It.IsAny<object>());

            //Act
            GetTransportOfferByIdQueryHandler fakeHandler = new GetTransportOfferByIdQueryHandler(fakeMapper.Object, fakeUnitOfWork.Object, fakeConfiguration.Object);
            var result = await fakeHandler.Handle(fakeQuery, new CancellationToken());
            //Assert
            Assert.IsType<TransportOfferDTO>(result);
        }

        [Fact]

        public async Task GetTransportTypes_ReturnTransportTypes()
        {

            //Arrange
            FakeTransaction fakeTransaction = new FakeTransaction();
            var fakeList = new List<TransportType>() { new TransportType() { Id = 1 } }.AsEnumerable();
            var fakeDTOlist = new List<TransportTypeDTO>() { new TransportTypeDTO() { Id = 1 } }.AsEnumerable();
            fakeTTypeRepository.Setup(_ => _.GetTAsync(It.IsAny<DynamicParameters>(), It.IsAny<IDbTransaction>(), It.IsAny<string>())).Returns(Task.FromResult(fakeList));
            fakeUnitOfWork.SetupGet(_ => _.Connection).Returns(fakeConnection.Object);


            fakeTTypeRepository.SetupGet(_ => _.Connection).Returns(fakeConnection.Object);
            fakeMapper.Setup(_ => _.Map<IEnumerable<TransportTypeDTO>>(It.IsAny<IEnumerable<TransportType>>())).Returns(fakeDTOlist);
            GetTransportTypesQuery fakeQuery = new GetTransportTypesQuery(It.IsAny<TransportTypeSearchRequest>());
            //Act
            GetTransportTypesQueryHandler fakeHandler = new GetTransportTypesQueryHandler(fakeMapper.Object,
                                                                                                  fakeUnitOfWork.Object,
                                                                                                  fakeConfiguration.Object);

            var result = await fakeHandler.Handle(fakeQuery, new CancellationToken());
            //Assert
            Assert.IsType<List<TransportTypeDTO>>(result);
        }

        [Fact]
        public async Task GetTransportTypeById_ReturnTransportType()
        {
            //Arrange
            var fakeTour = new TransportType();
            var fakeDTOtType = new TransportTypeDTO();
            fakeTTypeRepository.Setup(_ => _.GetTByIdAsync(It.IsAny<DynamicParameters>(), It.IsAny<IDbTransaction>(), It.IsAny<string>())).Returns(Task.FromResult(fakeTour));

            GetTransportTypeByIdQuery fakeQuery = new GetTransportTypeByIdQuery(It.IsAny<object>());

            //Act
            GetTransportTypeByIdQueryHandler fakeHandler = new GetTransportTypeByIdQueryHandler(fakeMapper.Object, fakeUnitOfWork.Object, fakeConfiguration.Object);
            var result = await fakeHandler.Handle(fakeQuery, new CancellationToken());
            //Assert
            Assert.IsType<TransportTypeDTO>(result);
        }

        [Fact]
        public async Task GetCities_ReturnCities()
        {
            //Arrange
            FakeTransaction fakeTransaction = new FakeTransaction();
            var fakeList = new List<City>() { new City() { Id = 1 } }.AsEnumerable();
            var fakeDTOlist = new List<CityDTO>() { new CityDTO() { Id = 1 } }.AsEnumerable();
            fakeCityRepository.Setup(_ => _.GetTAsync(It.IsAny<DynamicParameters>(), It.IsAny<IDbTransaction>(), It.IsAny<string>())).Returns(Task.FromResult(fakeList));
            fakeUnitOfWork.SetupGet(_ => _.Connection).Returns(fakeConnection.Object);


            fakeCityRepository.SetupGet(_ => _.Connection).Returns(fakeConnection.Object);
            fakeMapper.Setup(_ => _.Map<IEnumerable<CityDTO>>(It.IsAny<IEnumerable<City>>())).Returns(fakeDTOlist);
            GetCitiesQuery fakeQuery = new GetCitiesQuery(It.IsAny<CitySearchRequest>());
            //Act
            GetCitiesQueryHandler fakeHandler = new GetCitiesQueryHandler(fakeMapper.Object,
                                                                          fakeUnitOfWork.Object,
                                                                          fakeConfiguration.Object);

            var result = await fakeHandler.Handle(fakeQuery, new CancellationToken());
            //Assert
            Assert.IsType<List<CityDTO>>(result);
        }
        [Fact]
        public async Task GetCityById_ReturnTransportType()
        {
            //Arrange
            var fakeTour = new City();
            var fakeDTOtType = new CityDTO();
            fakeCityRepository.Setup(_ => _.GetTByIdAsync(It.IsAny<DynamicParameters>(), It.IsAny<IDbTransaction>(), It.IsAny<string>())).Returns(Task.FromResult(fakeTour));

            GetCityByIdQuery fakeQuery = new GetCityByIdQuery(It.IsAny<object>());

            //Act
            GetCityByIdQueryHandler fakeHandler = new GetCityByIdQueryHandler(fakeMapper.Object, fakeUnitOfWork.Object, fakeConfiguration.Object);
            var result = await fakeHandler.Handle(fakeQuery, new CancellationToken());
            //Assert
            Assert.IsType<CityDTO>(result);
        }
        [Fact]
        public async Task GetAttractionById_ReturnTransportType()
        {
            //Arrange
            var fakeTour = new Attraction();
            var fakeDTOtType = new AttractionDTO();
            fakeAttrRepository.Setup(_ => _.GetTByIdAsync(It.IsAny<DynamicParameters>(), It.IsAny<IDbTransaction>(), It.IsAny<string>())).Returns(Task.FromResult(fakeTour));

            GetAttractionByIdQuery fakeQuery = new GetAttractionByIdQuery(It.IsAny<AttractionSearchRequest>());

            //Act
            GetAttractionByIdQueryHandler fakeHandler = new GetAttractionByIdQueryHandler(fakeMapper.Object, fakeUnitOfWork.Object, fakeConfiguration.Object);
            var result = await fakeHandler.Handle(fakeQuery, new CancellationToken());
            //Assert
            Assert.IsType<AttractionDTO>(result);
        }

        [Fact]
        public async Task GetAttractions_ReturnCities()
        {
            //Arrange
            FakeTransaction fakeTransaction = new FakeTransaction();
            var fakeList = new List<Attraction>() { new Attraction() { Id = 1 } }.AsEnumerable();
            var fakeDTOlist = new List<AttractionDTO>() { new AttractionDTO() { Id = 1 } }.AsEnumerable();
            fakeAttrRepository.Setup(_ => _.GetTAsync(It.IsAny<DynamicParameters>(), It.IsAny<IDbTransaction>(), It.IsAny<string>())).Returns(Task.FromResult(fakeList));
            fakeUnitOfWork.SetupGet(_ => _.Connection).Returns(fakeConnection.Object);


            fakeCityRepository.SetupGet(_ => _.Connection).Returns(fakeConnection.Object);
            fakeMapper.Setup(_ => _.Map<IEnumerable<AttractionDTO>>(It.IsAny<IEnumerable<Attraction>>())).Returns(fakeDTOlist);
            GetAttractionsQuery fakeQuery = new GetAttractionsQuery(It.IsAny<AttractionSearchRequest>());
            //Act
            GetAttractionsQueryHandler fakeHandler = new GetAttractionsQueryHandler(fakeMapper.Object,
                                                                          fakeUnitOfWork.Object,
                                                                          fakeConfiguration.Object);

            var result = await fakeHandler.Handle(fakeQuery, new CancellationToken());
            //Assert
            Assert.IsType<List<AttractionDTO>>(result);
        }
    }
}
