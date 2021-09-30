using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace airport_back.Table
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasOne(u => u.Pilot)
            .WithMany(t => t.Flights)
            .HasForeignKey(u => u.PilotId);

            builder.HasOne(u => u.Plane)
           .WithMany(t => t.Flights)
           .HasForeignKey(u => u.PlaneId);

            builder.HasOne(u => u.Airport)
           .WithMany(t => t.Flights)
           .HasForeignKey(u => u.AirportId);
        }
    }
}