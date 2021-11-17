using airport_back.Table;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace airport_back
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Flight> flights { get; set; }
        public DbSet<Plane> planes { get; set; }
        public DbSet<Pilot> pilots { get; set; }
        public DbSet<Airport> airports { get; set; }

        public DbSet<Passenger> passengers { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            // Database.EnsureDeleted();
            //Database.EnsureCreated();
            //SqlConnectionFactory defaultFactory =
            //    new SqlConnectionFactory("Server=(localdb)\\MSSQLLocalDB;User=user1;Password=123;");

            //this.SetDefaultConnectionFactory(defaultFactory);
        }

        private void SetDefaultConnectionFactory(SqlConnectionFactory defaultFactory)
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PassengerConfiguration());
            modelBuilder.ApplyConfiguration(new AirportConfiguration());
            modelBuilder.ApplyConfiguration(new PilotConfiguration());
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}