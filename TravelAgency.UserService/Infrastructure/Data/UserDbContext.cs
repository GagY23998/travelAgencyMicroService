using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.UserService.Domain;

namespace TravelAgency.UserService.Infrastructure.Data
{
    public class UserDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public IConfiguration Configuration { get; }

        public UserDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString: Configuration.GetConnectionString("ConnectionStringRB"));
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasKey(key => new {key.UserId,key.RoleId});
            base.OnModelCreating(modelBuilder);
        }

    }
}
