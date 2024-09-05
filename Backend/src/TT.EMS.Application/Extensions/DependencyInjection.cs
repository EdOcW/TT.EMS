using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace TT.EMS.Application.Extensions;

public static class DependencyInjection
{
    private static readonly Assembly _assembly = typeof(DependencyInjection).Assembly;

    public static IServiceCollection AddApplication(this IServiceCollection services) =>
        services
            .AddMediatR(configuration =>
                configuration.RegisterServicesFromAssembly(_assembly));
}