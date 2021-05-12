using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.BookingService.Domain.BookingAggregate;
using TravelAgency.BookingService.Infrastructure.EntityTypeConfigurations;

namespace TravelAgency.BookingService.Infrastructure.Data
{
    public class BookingDbContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public IConfiguration Configuration { get; }

        public BookingDbContext(DbContextOptions<BookingDbContext> dbContext, IConfiguration configuration) : base(dbContext)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ConnectionStringRB"));
      
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PaymentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BookingTypeConfiguration());
        }
    }
    //public class BookingContextFactory : IDesignTimeDbContextFactory<BookingDbContext>
    //{
    //    public BookingContextFactory(IConfiguration configuration)
    //    {
    //        Configuration = configuration;
    //    }

    //    public IConfiguration Configuration { get; }

    //    public BookingDbContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<BookingDbContext>();
    //        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RBTravelAgency;Trusted_Connection=True;");

    //        return new BookingDbContext(optionsBuilder.Options,Configuration);
    //    }
    }