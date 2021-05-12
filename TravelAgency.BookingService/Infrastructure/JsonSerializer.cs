using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.Common;

namespace TravelAgency.BookingService.Infrastructure
{
    public class JsonSerializer : IJsonSerializer
    {

        public JsonSerializer()
        {

        }
        public TEvent DeserializeEvent<TEvent>(string payload) where TEvent : IDomainEvent
        {
            var result = (TEvent)JsonConvert.DeserializeObject(payload,typeof(TEvent));
            return result;
        }

        public string SerializeEvent<TEvent>(TEvent @event) where TEvent : IDomainEvent
        {
            var result = JsonConvert.SerializeObject(@event, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Error });
            return result;
        }
    }
}
