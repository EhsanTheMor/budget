using budget_back.Domain.AggregatedModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace budget_back.Infrastructure.EntityTypeConfigurations;

public class BankAccountEntityTypeConfiguration : IEntityTypeConfiguration<BankAccount>
{
    public void Configure(EntityTypeBuilder<BankAccount> builder)
    {
        builder.ToTable("BankAccounts");

        builder.HasKey(account => account.Id);

        builder.Property(account => account.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(account => account.BankName)
            .HasMaxLength(100);

        builder.Property(account => account.InitialBalance)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.HasOne(account => account.User)
            .WithMany(user => user.BankAccounts)
            .HasForeignKey(account => account.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasMany(account => account.Expences)
            .WithOne(expence => expence.BankAccount)
            .HasForeignKey(expence => expence.BankAccountId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Navigation(account => account.Expences)
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.Ignore(account => account.RemainingBalance);
    }
}
