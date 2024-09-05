using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TT.EMS.Application.Interfaces;
using TT.EMS.Domain.Employee;
using TT.EMS.Infrastructure.Persistence;
using TT.EMS.Infrastructure.Persistence.Repositories;
using TT.EMS.Infrastructure.Policies;
using TT.EMS.Infrastructure.Interfaces;

namespace TT.EMS.Infrastructure.Extension;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) =>
        services
            .AddScoped<IRetryPolicy, RetryPolicy>()
            .RegisterDatabase(configuration)
            .InitializeDatabaseAsync().GetAwaiter().GetResult();

    private static IServiceCollection RegisterDatabase(this IServiceCollection services, IConfiguration configuration) =>
    services
        .AddDbContext<ApplicationDbContext>((provider, options) =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")!);
            var retryPolicy = provider.GetRequiredService<IRetryPolicy>();
        })
        .AddScoped<IDatabaseInitializer, DatabaseInitializer>()
        .AddScoped<IUnitOfWork, UnitOfWork>()
        .AddScoped<IEmployeeRepository, EmployeeRepository>();

    private static async Task<IServiceCollection> InitializeDatabaseAsync(this IServiceCollection services)
    {
        using var scope = services.BuildServiceProvider().CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<IDatabaseInitializer>();
        await dbContext.InitializeDatabaseAsync();

        return services;
    }
}