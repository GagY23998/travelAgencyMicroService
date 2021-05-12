using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelAgency.BookingService.Domain.BookingAggregate;
using TravelAgency.BookingService.Domain.Common;
using TravelAgency.BookingService.Domain.Events;
using Xunit;
namespace UnitTesting.BookingService
{
    public class AggreggateRootTests
    {
        Booking root = new Booking();

        public AggreggateRootTests()
        {
            root = Activator.CreateInstance<Booking>();
        }
        [Fact]
        public void GetUnloadedEvents_ifNotExist_listEmpty()
        {
            //Arrange

            //Act
            var events = root.GetUnloadedEvents();

            //Assert
            Assert.Empty(events);
        }

        [Fact]
        public void GetUnloadedEvents_ifExist_listNotEmpty()
        {
            //Arrange
            var instance = Activator.CreateInstance<BookingCreatedEvent>();
            root.AddEvent(instance);
            //Act
            var events = root.GetUnloadedEvents();

            //Assert
            Assert.NotEmpty(events);
        }

        [Fact]
        public void addEvent_ifAdded_listNotEmpty()
        {
            //Arrange
            IDomainEvent domainEvent = Activator.CreateInstance<BookingCreatedEvent>();

            //Act
            root.AddEvent(domainEvent);

            //Assert
            Assert.NotEmpty(root.GetUnloadedEvents());
        }
        [Fact]
        public void addEvent_ifNotAdded_listSameSize()
        {
            //Arrange
            IDomainEvent @event = Activator.CreateInstance<BookingCreatedEvent>();

            //Act
            int firstSize = root.GetUnloadedEvents().Count();
          //  root.AddEvent(@event);
            int currentSize = root.GetUnloadedEvents().Count();
            //Assert
            Assert.Equal(firstSize, currentSize);
        }

        [Fact]
        public void clearEvent_ifSuccess_listEmpty()
        {
            //Arrange

            //Act
            root.Clear();
            var events = root.GetUnloadedEvents();
            //Assert
            Assert.Empty(events);
        }
        [Fact]
        public void removeEvent_ifSuccessufull_eventNotInList()
        {

            //Arrange
            IDomainEvent @event = Activator.CreateInstance<BookingCreatedEvent>();
            IDomainEvent event2 = Activator.CreateInstance<BookingCreatedEvent>();
            root.AddEvent(@event);
            root.AddEvent(event2);
            //Act

            root.RemoveEvent(event2);

            //Assert
            Assert.DoesNotContain(event2, root.GetUnloadedEvents());
        }
        [Fact]
        public void loadFromhistory_ifloaded_CheckIfSame()
        {
            //Arrange
            IDomainEvent @event = Activator.CreateInstance<BookingCreatedEvent>();
            IDomainEvent event2 = Activator.CreateInstance<BookingCreatedEvent>();
            Guid id = @event._Id;
            Booking booking = new Booking();
            List<IDomainEvent> events = new List<IDomainEvent> { @event, event2 };
            var enumerableEvents = events.AsEnumerable();

            //Act
            root.LoadFromHistory(enumerableEvents);
            //Assert
            Assert.Equal(root.Id, id);
        }
    }
}
