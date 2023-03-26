using Zekju.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Zekju.Infrastructure.Configuration;

public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.ToTable("Subscriptions");

        builder.Property(p => p.AgencyId).HasColumnName("agency_id");
        builder.Property(p => p.OriginCityId).HasColumnName("origin_city_id");
        builder.Property(p => p.DestinationCityId).HasColumnName("destination_city_id");
        
        builder.HasKey(s => new { s.AgencyId, s.OriginCityId, s.DestinationCityId });
        builder.HasIndex(p => new { p.AgencyId, p.OriginCityId, p.DestinationCityId }).IsUnique(false);
    }
}