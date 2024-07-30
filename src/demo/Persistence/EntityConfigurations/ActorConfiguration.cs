using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ActorConfiguration : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        builder.ToTable("Actors").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.Name).HasColumnName("Name");
        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);

        // Relationship configuration
        builder.HasMany(a => a.EventsAsActor1)
               .WithOne(e => e.Actor1)
               .HasForeignKey(e => e.Actor1Id)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(a => a.EventsAsActor2)
               .WithOne(e => e.Actor2)
               .HasForeignKey(e => e.Actor2Id)
               .OnDelete(DeleteBehavior.NoAction);
    }
}