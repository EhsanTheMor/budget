using budget_back.Domain.AggregatedModels;
using Microsoft.EntityFrameworkCore;

namespace budget_back.Application.Abstractions.Persist;

public interface IBudgetDbContext
{
    DbSet<User> Users { get; }
    DbSet<Category> Categories { get; }
    DbSet<Travel> Travels { get; }
    DbSet<Family> Families { get; }
    DbSet<Building> Buildings { get; }
    DbSet<ExpenseScope> ExpenseScopes { get; }
    DbSet<Expence> Expences { get; }
    DbSet<BankAccount> BankAccounts { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
