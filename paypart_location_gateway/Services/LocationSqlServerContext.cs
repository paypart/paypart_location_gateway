using Microsoft.EntityFrameworkCore;
using paypart_location_gateway.Models;

namespace paypart_location_gateway.Services
{
    public class LocationSqlServerContext : DbContext
    {
        public LocationSqlServerContext(DbContextOptions<LocationSqlServerContext> options) : base(options)
        {

        }

        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<State>().ToTable("State");
        }
    }
}
