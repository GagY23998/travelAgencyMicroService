using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.BookingService.Application.Commands;
using TravelAgency.BookingService.Domain.BookingAggregate;
using TravelAgency.BookingService.Domain.Common;
using TravelAgency.BookingService.Domain.Events;
using Xunit;

namespace UnitTesting.BookingService.Events
{
    public class BookingEventsTest
    {
        public class BookingCreated_WhenThereIsNoCreatedBooking_EventTest : AggregateRootTestSetup<Booking>
        {
            Guid tourOfferId = Guid.NewGuid();
            Guid hotelOfferId = Guid.NewGuid();
            Guid transportOfferId = Guid.NewGuid();
            Mock<IMediator> _mediator;
            public override IEnumerable<IDomainEvent>Given()
            {
                return new List<IDomainEvent>();
                //yield return new BookingCreatedEvent(1, tourOfferId, hotelOfferId, transportOfferId, DateTime.Now, new Payment(), true);
            }

            public override void When()
            {
                //Kreriati na agregatu javne funkcije za kreiranje evenata
                root.CreateBooking(tourOfferId, hotelOfferId, transportOfferId, DateTime.Now, new Payment());
            }

            [Fact]
            public void when_New_Booking_is_Added()
            {
                //Arrange
                var lastState = root.GetUnloadedEvents();
                //Assert 
                Assert.Contains(lastState, _ => _.GetType() == typeof(BookingCreatedEvent));
            }
        }
        public class BookingCreated_WhenThereIsCreatedBooking_EventTest : AggregateRootTestSetup<Booking>
        {
            Guid tourOfferId = Guid.NewGuid();
            Guid hotelOfferId = Guid.NewGuid();
            Guid transportOfferId = Guid.NewGuid();
            Mock<IMediator> _mediator;
            public override IEnumerable<IDomainEvent> Given()
            {
                yield return new BookingCreatedEvent(2 ,hotelOfferId, transportOfferId, DateTime.Now, new Payment(), true);
            }

            public override void When()
            {
                //Kreriati na agregatu javne funkcije za kreiranje evenata
                root.CreateBooking(tourOfferId, hotelOfferId, transportOfferId, DateTime.Now, new Payment());
            }

            [Fact]
            public void when_New_Booking_is_Added()
            {
                //Arrange
                var lastState = root.GetUnloadedEvents();
                //Assert 
                Assert.Contains(lastState, _ => _.GetType() == typeof(BookingCreatedEvent) && !(_.Version >2));
            }
        }


        public class BookingCanceled_WhenBookingIsCreated_EventTest : AggregateRootTestSetup<Booking>
        {
            public Guid ID { get; set; }
            private BookingCanceledEvent @event = new BookingCanceledEvent();
            public BookingCanceled_WhenBookingIsCreated_EventTest()
            {
                ID = Guid.NewGuid();
            }
            public override IEnumerable<IDomainEvent> Given()
            {
                yield return new BookingCreatedEvent();
            }

            public override void When()
            {
                root.CancelBooking(ID);
            }

            [Fact]
            public void when_BookingIsCanceled_raiseBookingCanceledEvent()
            {
                //Act
                var events = root.GetUnloadedEvents();

                //Assert
                Assert.Contains(events, _ => _.GetType() == typeof(BookingCanceledEvent));
            }
        }
        public class BookingCanceled_WhenBookingIsNotCreated_EventTest : AggregateRootTestSetup<Booking>
        {
            public Guid ID { get; set; }
            private BookingCanceledEvent @event = new BookingCanceledEvent();
            public BookingCanceled_WhenBookingIsNotCreated_EventTest()
            {
                ID = Guid.NewGuid();
            }
            public override IEnumerable<IDomainEvent> Given()
            {
                return new List<IDomainEvent>();
            }

            public override void When()
            {

                root.CancelBooking(ID);
            }

            [Fact]
            public void when_BookingIsNotCanceled_checkForBookingCanceledEvent()
            {
                //Act
                var events = root.GetUnloadedEvents();

                //Assert
                Assert.DoesNotContain(events, _ => _.GetType() == typeof(BookingCanceledEvent));
            }
        }


        public class BookingCompleted_WhenThereIsBookingCreated_EventTest : AggregateRootTestSetup<Booking>
        {
            private Guid Id = new Guid();
            public override IEnumerable<IDomainEvent> Given()
            {
                yield return new BookingCreatedEvent();
            }

            public override void When()
            {
                root.CompleteBooking();
            }
            [Fact]
            public void when_BookingIsRefused_cancel()
            {

                //Act
                var events = root.GetUnloadedEvents();

                //Assert
                Assert.Contains(events, _ => _.GetType() == typeof(BookingCompletedEvent));
            }
        }
    }
}
