using budget_back.Domain.AggregatedModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace budget_back.Infrastructure.EntityTypeConfigurations;

public class ExpenseScopeEntityTypeConfiguration : IEntityTypeConfiguration<ExpenseScope>
{
    public void Configure(EntityTypeBuilder<ExpenseScope> builder)
    {
        builder.ToTable("ExpenseScopes");

        builder.HasKey(scope => scope.Id);

        builder.Property(scope => scope.Type)
            .HasConversion<string>()
            .HasMaxLength(32)
            .IsRequired();

        builder.HasMany(scope => scope.Expences)
            .WithOne(expence => expence.ExpenseScope)
            .HasForeignKey(expence => expence.ExpenseScopeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(scope => scope.Expences)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
