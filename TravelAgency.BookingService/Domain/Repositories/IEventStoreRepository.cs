using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.Common;

namespace TravelAgency.BookingService.Domain.Repositories
{
    public interface IEventStoreRepository
    {
        Task<Entity> GetAggregateById(Guid id);
        Task AppendEvent(EventStore @event);
    }
}
