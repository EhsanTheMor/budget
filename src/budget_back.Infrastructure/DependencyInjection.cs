using budget_back.Application.Abstractions.Persist;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace budget_back.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string is not configured");
        }

        services.AddDbContext<BudgetDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });

        services.AddScoped<IBudgetDbContext>(provider => provider.GetRequiredService<BudgetDbContext>());

        return services;
    }
}
