using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.BookingAggregate;

namespace TravelAgency.BookingService.Infrastructure.EntityTypeConfigurations
{
    public class PaymentTypeConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Ignore(_ => _.Version);
            builder.Property<Guid>(_ => _.Id).IsRequired();
            builder.Property<DateTime>(_ => _.PaymentDate).IsRequired();
            builder.Property<float>(_ => _.Price).IsRequired();
        }
    }
}
