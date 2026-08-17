using budget_back.Application.Abstractions.Persist;
using budget_back.Domain.AggregatedModels;
using Microsoft.EntityFrameworkCore;

namespace budget_back.Infrastructure;

public class BudgetDbContext : DbContext, IBudgetDbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Travel> Travels => Set<Travel>();
    public DbSet<Family> Families => Set<Family>();
    public DbSet<Building> Buildings => Set<Building>();
    public DbSet<ExpenseScope> ExpenseScopes => Set<ExpenseScope>();
    public DbSet<Expence> Expences => Set<Expence>();
    public DbSet<BankAccount> BankAccounts => Set<BankAccount>();

    public BudgetDbContext(DbContextOptions<BudgetDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BudgetDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
