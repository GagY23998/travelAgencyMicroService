using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain;

namespace TravelAgency.HotelService.Infrastructure.EntityTypeConfigurations
{
    public class HotelRoomConfiguration : IEntityTypeConfiguration<HotelRoom>
    {
        public void Configure(EntityTypeBuilder<HotelRoom> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Capacity).IsRequired();
            builder.HasOne(_ => _.Hotel);
            builder.HasOne(_ => _.RoomType);
        }
    }
}
