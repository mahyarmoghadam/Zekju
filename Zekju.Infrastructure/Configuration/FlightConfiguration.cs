using Zekju.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Zekju.Infrastructure.Configuration;

public class FlightConfiguration : IEntityTypeConfiguration<Flight>
{
    public void Configure(EntityTypeBuilder<Flight> builder)
    {
        builder.ToTable("Flights");

        // Properties
        builder.Property(p => p.Id).HasColumnName("flight_id").IsUnicode();
        builder.Property(p => p.RouteId).HasColumnName("route_id");
        builder.Property(p => p.DepartureTime).HasColumnName("departure_time").HasColumnType("timestamp without time zone");
        builder.Property(p => p.ArrivalDate).HasColumnName("arrival_time").HasColumnType("timestamp without time zone");
        builder.Property(p => p.AirlineId).HasColumnName("airline_id");

        // Index
        builder.HasIndex(p => p.DepartureTime).IsUnique(false);
        builder.HasIndex(p => p.RouteId).IsUnique(false);
        
        //Relations
        builder.HasOne<Route>(flight => flight.Route)
            .WithMany(route => route.Flights)
            .HasForeignKey(flight => flight.RouteId);
    }
}