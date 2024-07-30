using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DenemeConfiguration : IEntityTypeConfiguration<Deneme>
{
    public void Configure(EntityTypeBuilder<Deneme> builder)
    {
        builder.ToTable("Denemes").HasKey(d => d.Id);

        builder.Property(d => d.Id).HasColumnName("Id").IsRequired();
        builder.Property(d => d.ActivationKey).HasColumnName("ActivationKey");
        builder.Property(d => d.IsVerified).HasColumnName("IsVerified");
        builder.Property(d => d.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(d => d.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(d => d.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(d => !d.DeletedDate.HasValue);
    }
}