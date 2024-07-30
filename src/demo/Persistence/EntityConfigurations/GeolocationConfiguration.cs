using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class GeolocationConfiguration : IEntityTypeConfiguration<Geolocation>
{
    public void Configure(EntityTypeBuilder<Geolocation> builder)
    {
        builder.ToTable("Geolocations").HasKey(g => g.Id);

        builder.Property(g => g.Id).HasColumnName("Id").IsRequired();
        builder.Property(g => g.Country).HasColumnName("Country");
        builder.Property(g => g.Admin1).HasColumnName("Admin1");
        builder.Property(g => g.Admin2).HasColumnName("Admin2");
        builder.Property(g => g.Latitude).HasColumnName("Latitude");
        builder.Property(g => g.Longitude).HasColumnName("Longitude");
        builder.Property(g => g.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(g => g.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(g => g.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(g => !g.DeletedDate.HasValue);
    }
}