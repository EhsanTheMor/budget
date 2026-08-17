using budget_back.Domain.AggregatedModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace budget_back.Infrastructure.EntityTypeConfigurations;

public class ExpenceEntityTypeConfiguration : IEntityTypeConfiguration<Expence>
{
    public void Configure(EntityTypeBuilder<Expence> builder)
    {
        builder.ToTable("Expences");

        builder.HasKey(expence => expence.Id);

        builder.Property(expence => expence.Description)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(expence => expence.Amount)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(expence => expence.CreatedAt)
            .IsRequired();
    }
}
