using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Events").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
        builder.Property(e => e.Date).HasColumnName("Date");
        builder.Property(e => e.EventType).HasColumnName("EventType");
        builder.Property(e => e.Actor1Id).HasColumnName("Actor1Id");
        builder.Property(e => e.Actor2Id).HasColumnName("Actor2Id");
        builder.Property(e => e.GeolocationId).HasColumnName("GeolocationId");
        builder.Property(e => e.SourceId).HasColumnName("SourceId");
        builder.Property(e => e.Description).HasColumnName("Description");
        builder.Property(e => e.Fatalities).HasColumnName("Fatalities");
        builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(e => !e.DeletedDate.HasValue);

                builder.HasOne(e => e.Actor1)
               .WithMany(a => a.EventsAsActor1)
               .HasForeignKey(e => e.Actor1Id)
               .OnDelete(DeleteBehavior.NoAction);
                               builder.HasOne(e => e.Actor2)
               .WithMany(a => a.EventsAsActor2)
               .HasForeignKey(e => e.Actor2Id)
               .OnDelete(DeleteBehavior.NoAction);
    }
}