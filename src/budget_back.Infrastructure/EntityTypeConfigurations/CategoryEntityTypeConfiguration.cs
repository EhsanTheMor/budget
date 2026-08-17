using budget_back.Domain.AggregatedModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace budget_back.Infrastructure.EntityTypeConfigurations;

public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category");

        builder.HasKey(category => category.Id);

        builder.Property(category => category.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(category => category.Description)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(category => category.Type)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(category => category.Icon)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(category => category.Color)
            .HasMaxLength(20)
            .IsRequired();

        builder.HasOne(category => category.ExpenseScope)
            .WithOne()
            .HasForeignKey<Category>(category => category.ExpenseScopeId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasIndex(category => category.ExpenseScopeId)
            .IsUnique();
    }
}
