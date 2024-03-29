﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.BookingService.Infrastructure.Services
{
    public interface IBookingEventStoreSettings
    {
         public string BooksCollectionName { get; set; }
         public string ConnectionString {get;set;}
         public string DatabaseName { get; set; }
    }
}
