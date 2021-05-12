using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.BookingAggregate;

namespace TravelAgency.BookingService.Infrastructure.EntityTypeConfigurations
{
    public class BookingTypeConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Ignore(_ => _.Version);
            builder.Property<Guid>(_ => _.HotelOfferId).IsRequired();
            builder.Property<Guid>(_ => _.TransportOfferId).IsRequired();
            builder.Property<DateTime>(_ => _.ReservationDate).ValueGeneratedOnAdd();
            builder.Property<bool>(_ => _.CanceledStatus).IsRequired();
            builder.Property<bool>(_ => _.Completed).IsRequired();
            
        }
    }
}
