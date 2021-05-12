using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.BookingService.Domain.Common
{
    public class EventStore
    {
        public Guid AggregateId { get; set; }
        public long Version { get; set; }
        public string Event { get; set; }
        public string Payload { get; set; }
        public DateTime Date { get; set; }

        public EventStore(Guid aggregateId,long version,string @event,string payload,DateTime date)
        {
            AggregateId = aggregateId;
            Version = version;
            Event = @event;
            Payload = payload;
            Date = date;
        }
    }
}
