using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.BookingAggregate;
using TravelAgency.BookingService.Domain.Common;
using TravelAgency.BookingService.Domain.Repositories;

namespace TravelAgency.BookingService.Infrastructure.Services
{
    public class EventStoreRepository : IEventStoreRepository
    {
        IMongoCollection<EventStore> _bookings;
        IJsonSerializer _serializer;
        public EventStoreRepository(IBookingEventStoreSettings settings,IJsonSerializer serializer)
        {
            _serializer = serializer;
            var mongoDbClient = new MongoClient(settings.ConnectionString);
            var dB = mongoDbClient.GetDatabase(settings.DatabaseName);
            _bookings = dB.GetCollection<EventStore>(settings.BooksCollectionName);
        }
        public async Task AppendEvent(EventStore @event)
        {
            await _bookings.InsertOneAsync(@event);
        }

        public async Task<Entity> GetAggregateById(Guid id) 
        {
            var aggregateInstance = Activator.CreateInstance<Booking>();
            var result = await _bookings.FindAsync(_ => _.AggregateId == id);
            var listResult = result.ToList();
            foreach (var item in listResult)
            {
                var deserializedEvent = _serializer.DeserializeEvent<IDomainEvent>(item.Payload);
                aggregateInstance.AddEvent(deserializedEvent);
            }
            aggregateInstance.LoadFromHistory(aggregateInstance.GetUnloadedEvents());


            return aggregateInstance;
        }
    }
}
