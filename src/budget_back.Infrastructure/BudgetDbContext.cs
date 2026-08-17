using budget_back.Domain.AggregatedModels;
using Microsoft.EntityFrameworkCore;

namespace budget_back.Infrastructure;

public class BudgetDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }

    public BudgetDbContext(DbContextOptions<BudgetDbContext> options) : base(options)
    {
    }
}