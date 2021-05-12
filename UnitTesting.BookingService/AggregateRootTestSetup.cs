using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelAgency.BookingService.Domain.Common;
using Xunit;

namespace UnitTesting.BookingService
{
    // Logic for event sourcing UnitTesting
    //given specific situation
    //when specific event occurs
    //check if some event happend successufully
    public abstract class AggregateRootTestSetup<T> : IDisposable where T : class,new()
    {


        Exception ex = null;
        private IList<IDomainEvent> _events;
        public T root = null;
        public abstract IEnumerable<IDomainEvent> Given();
        public abstract void When();

        public AggregateRootTestSetup()
        {
            root = new T();
            _events = Given().ToList();
            foreach (var item in _events)
            {
                ((dynamic)root).AddEvent(item);
            }
            try
            {
                When();
            }
            catch (Exception e)
            {
                ex = e; 
            }
        }
        public void Dispose()
        {
            _events.Clear();
        }

    }
}
