using budget_back.Domain.AggregatedModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace budget_back.Infrastructure.EntityTypeConfigurations;

public class FamilyEntityTypeConfiguration : IEntityTypeConfiguration<Family>
{
    public void Configure(EntityTypeBuilder<Family> builder)
    {
        builder.ToTable("Families");

        builder.HasKey(family => family.Id);

        builder.Property(family => family.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(family => family.Description)
            .HasMaxLength(500);

        builder.HasOne(family => family.ExpenseScope)
            .WithOne()
            .HasForeignKey<Family>(family => family.ExpenseScopeId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasIndex(family => family.ExpenseScopeId)
            .IsUnique();

        builder.HasOne(family => family.Manager)
            .WithMany()
            .HasForeignKey(family => family.ManagerId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasMany(family => family.Users)
            .WithMany(user => user.Families)
            .UsingEntity(j => j.ToTable("FamilyUsers"));

        builder.Navigation(family => family.Users)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
