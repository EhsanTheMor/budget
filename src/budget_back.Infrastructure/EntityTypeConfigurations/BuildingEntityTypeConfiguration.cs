using budget_back.Domain.AggregatedModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace budget_back.Infrastructure.EntityTypeConfigurations;

public class BuildingEntityTypeConfiguration : IEntityTypeConfiguration<Building>
{
    public void Configure(EntityTypeBuilder<Building> builder)
    {
        builder.ToTable("Building");

        builder.HasKey(building => building.Id);

        builder.Property(building => building.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(building => building.Description)
            .HasMaxLength(500);

        builder.Property(building => building.Address)
            .HasMaxLength(300);

        builder.HasOne(building => building.ExpenseScope)
            .WithOne()
            .HasForeignKey<Building>(building => building.ExpenseScopeId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasIndex(building => building.ExpenseScopeId)
            .IsUnique();

        builder.HasOne(building => building.Manager)
            .WithMany()
            .HasForeignKey(building => building.ManagerId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasMany(building => building.Users)
            .WithMany(user => user.Buildings)
            .UsingEntity(j => j.ToTable("BuildingUser"));

        builder.Navigation(building => building.Users)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
