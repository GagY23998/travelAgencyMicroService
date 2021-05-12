using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain;

namespace TravelAgency.HotelService.Infrastructure.EntityTypeConfigurations
{
    public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
    {
        public void Configure(EntityTypeBuilder<RoomType> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Type).IsRequired();
        }
    }
}
