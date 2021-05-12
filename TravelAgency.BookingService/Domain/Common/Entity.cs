using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.BookingService.Domain.Common
{
    public abstract class Entity :IEventSourcing
    {
        public Guid Id { get; set; }
        public long Version { get; set; }
        List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
        public void AddEvent(IDomainEvent @event)
        {
            _domainEvents.Add(@event);
        }

        public void ApplyEvent(IDomainEvent @event,long version)
        {
            ((dynamic)this).Apply((dynamic)@event);
            Version = version;
        }


        public void Clear()
        {
            _domainEvents?.Clear();
        }

        public IEnumerable<IDomainEvent> GetUnloadedEvents() => _domainEvents?.AsEnumerable();


        public void RemoveEvent(IDomainEvent @event)
        {
            _domainEvents?.Remove(@event);
        }

        public void LoadFromHistory(IEnumerable<IDomainEvent> events)
        {
            foreach (var @event in events.Reverse())
            {
                ApplyEvent(@event,@event.Version);
            }
        }
    }
}
