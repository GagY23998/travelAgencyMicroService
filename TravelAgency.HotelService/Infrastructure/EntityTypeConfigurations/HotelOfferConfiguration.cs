using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain;

namespace TravelAgency.HotelService.Infrastructure.EntityTypeConfigurations
{
    public class HotelOfferConfiguration : IEntityTypeConfiguration<HotelOffer>
    {
        public void Configure(EntityTypeBuilder<HotelOffer> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.HasOne(_ => _.Hotel);
            builder.HasOne(_ => _.HotelRoom);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
            builder.Property(_ => _.NumberOfRooms).IsRequired();
            builder.Property(_ => _.StartDate).IsRequired();
            builder.Property(_ => _.ExpirationDate).IsRequired();

        }
    }
}
