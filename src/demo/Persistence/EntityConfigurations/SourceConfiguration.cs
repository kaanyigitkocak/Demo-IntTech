using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SourceConfiguration : IEntityTypeConfiguration<Source>
{
    public void Configure(EntityTypeBuilder<Source> builder)
    {
        builder.ToTable("Sources").HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.Name).HasColumnName("Name");
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
    }
}