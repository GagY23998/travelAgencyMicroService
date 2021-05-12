using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.Common;

namespace TravelAgency.BookingService.Infrastructure
{
    public interface IJsonSerializer
    {
        TEvent DeserializeEvent<TEvent>(string payload) where TEvent : IDomainEvent;
        string SerializeEvent<TEvent>(TEvent @event) where TEvent : IDomainEvent;

    }
}
