using budget_back.Domain.AggregatedModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace budget_back.Infrastructure.EntityTypeConfigurations;

public class TravelEntityTypeConfiguration : IEntityTypeConfiguration<Travel>
{
    public void Configure(EntityTypeBuilder<Travel> builder)
    {
        builder.ToTable("Travel");

        builder.HasKey(travel => travel.Id);

        builder.Property(travel => travel.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(travel => travel.Description)
            .HasMaxLength(500);

        builder.HasOne(travel => travel.ExpenseScope)
            .WithOne()
            .HasForeignKey<Travel>(travel => travel.ExpenseScopeId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasIndex(travel => travel.ExpenseScopeId)
            .IsUnique();

        builder.HasOne(travel => travel.Manager)
            .WithMany()
            .HasForeignKey(travel => travel.ManagerId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasMany(travel => travel.Users)
            .WithMany(user => user.Travels)
            .UsingEntity(j => j.ToTable("TravelUser"));

        builder.Navigation(travel => travel.Users)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
