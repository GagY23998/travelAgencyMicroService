using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.BookingAggregate;
using TravelAgency.BookingService.Domain.Common;
using TravelAgency.BookingService.Domain.Events;
using TravelAgency.BookingService.Domain.Repositories;
using TravelAgency.BookingService.Infrastructure;
using TravelAgency.BookingService.Infrastructure.Services;
using Xunit;

namespace UnitTesting.BookingService
{
    public class IEventStoreRepositoryTest
    {
        Mock<IEventStoreRepository> store;
        //Mock<IJsonSerializer> mockSerializer;
        //Mock<IBookingEventStoreSettings> mockSettings;
        public IEventStoreRepositoryTest()
        {
            //mockSettings = new Mock<IBookingEventStoreSettings>();
            //mockSerializer = new Mock<IJsonSerializer>();
            store = new Mock<IEventStoreRepository>();
        }

        [Fact]
        public async Task GetAggregateById_IfExists_ReturnAggregate()
        {
            //Arrange
            Booking aggregateRoot = new Booking();
            store.Setup(_ => _.GetAggregateById(It.IsAny<Guid>())).Returns(Task.FromResult((Entity)aggregateRoot));
            Guid aggregateId = Guid.NewGuid();
            //Act
            var result = await store.Object.GetAggregateById(aggregateId);
            //Assert
            Assert.IsType<Booking>(result);
        }

        [Fact]
        public async Task SaveEvent_IfSaved_ReturnTrue()
        {
            //Arrange
            Guid fakeId = Guid.NewGuid();
            EventStore fakeEstore = new EventStore(fakeId,1,"","",DateTime.Now);
            Booking fakeBooking = new Booking();
            fakeBooking.Id = fakeId;
            BookingCreatedEvent @event = new BookingCreatedEvent();
            store.Setup(_ => _.GetAggregateById(fakeId)).Returns(Task.FromResult((Entity)fakeBooking));
            //Act
            //await store.Object.AppendEvent(fakeEstore);
            var result = await store.Object.GetAggregateById(fakeId);
            //Assert
            Assert.IsType<Booking>((Booking)result);
            Assert.Equal(fakeId, ((Booking)result).Id);
        }
    }
}
