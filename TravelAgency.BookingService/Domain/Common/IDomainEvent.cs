using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.BookingService.Domain.Common
{
    public interface IDomainEvent
    {
        public Guid _Id { get; }
        public long Version { get;}
    }
}
