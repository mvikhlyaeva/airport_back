using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace airport_back.Table
{
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasOne(u => u.Flight)
            .WithMany(t => t.Passengers)
            .HasForeignKey(u => u.FlightId);
        }
    }
}