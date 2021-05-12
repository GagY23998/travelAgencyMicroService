using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.HotelService.Domain;
using TravelAgency.HotelService.Infrastructure.EntityTypeConfigurations;

namespace TravelAgency.HotelService.Infrastructure.Data
{
    public class HotelDbContext : DbContext
    {
        public DbSet<HotelOffer> HotelOffers { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<HotelReview> HotelReviews {get; set;}
        public IConfiguration Configuration { get; }

        public HotelDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("ConnectionStringRB"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new HotelOfferConfiguration());
            modelBuilder.ApplyConfiguration(new HotelConfiguration());
            modelBuilder.ApplyConfiguration(new HotelRoomConfiguration());
            modelBuilder.ApplyConfiguration(new RoomTypeConfiguration());
        }
    }
}
