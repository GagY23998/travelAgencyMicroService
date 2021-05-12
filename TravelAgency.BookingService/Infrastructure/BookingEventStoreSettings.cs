using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration;

namespace TravelAgency.BookingService.Infrastructure.Services
{
    public class BookingEventStoreSettings : IBookingEventStoreSettings
    {
        public string BooksCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
