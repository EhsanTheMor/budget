using Microsoft.Extensions.DependencyInjection;

namespace budget_back.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}
