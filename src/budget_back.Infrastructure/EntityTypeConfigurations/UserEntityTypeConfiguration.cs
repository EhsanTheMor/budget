using budget_back.Domain.AggregatedModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace budget_back.Infrastructure.EntityTypeConfigurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(user => user.Id);

        builder.Property(user => user.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(user => user.LastName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(user => user.Username)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(user => user.Username)
            .IsUnique();

        builder.Property(user => user.Email)
            .HasMaxLength(256)
            .IsRequired();

        builder.HasIndex(user => user.Email)
            .IsUnique();

        builder.Property(user => user.Password)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(user => user.CreatedAt)
            .IsRequired();

        builder.Ignore(user => user.Categories);

        builder.Navigation(user => user.BankAccounts)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
