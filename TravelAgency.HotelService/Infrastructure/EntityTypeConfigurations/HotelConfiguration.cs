using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain;

namespace TravelAgency.HotelService.Infrastructure.EntityTypeConfigurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
            builder.Property(_ => _.Name).IsRequired();
            builder.Property(_ => _.CityId).IsRequired();
            builder.Property(_ => _.Description).HasDefaultValue("Description to be added");
        }
    }
}
