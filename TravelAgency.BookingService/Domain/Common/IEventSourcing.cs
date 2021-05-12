using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.BookingService.Domain.Common
{
    public interface IEventSourcing
    {
        void AddEvent(IDomainEvent @event);
        void RemoveEvent(IDomainEvent @event);
        void Clear();
        void ApplyEvent(IDomainEvent @event,long version);
        IEnumerable<IDomainEvent> GetUnloadedEvents();
        void LoadFromHistory(IEnumerable<IDomainEvent> events);
    }
}
