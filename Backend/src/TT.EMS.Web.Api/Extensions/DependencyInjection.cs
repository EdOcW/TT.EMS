using System.Text.Json.Serialization;
using Mapster;
using MapsterMapper;
using Microsoft.OpenApi.Models;
using TT.EMS.Web.Api.Constants;
using TT.EMS.Web.Api.Extensions;
using TT.EMS.Web.Api.Mappings;

namespace TT.EMS.Web.Api.Extensions;

public static class DependencyInjection
{
    private static readonly TypeAdapterConfig typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
    private static readonly IList<IRegister> _ = typeAdapterConfig.Scan(typeof(EmployeeMapping).Assembly);

    public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration) =>
        services
            .RegisterSwagger()
            .RegisterMapster()
            .ConfigureHttpJsonOptions()
            .AddCorses(configuration);

    private static IServiceCollection AddCorses(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddCors(options =>
            {
                options.AddPolicy(PresentationConstants.Cors.CorsPolicyName,
                builder => builder
                    .WithOrigins(configuration.GetSection("CorsAllowedOrigins").Get<string[]>()!)
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
    }

    private static IServiceCollection RegisterSwagger(this IServiceCollection services) =>
        services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen(options =>
            {
                options
                    .SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "QuotationApp.Web.Api",
                        Version = "v1"
                    });
            });

    private static IServiceCollection RegisterMapster(this IServiceCollection services) =>
        services
            .AddSingleton(typeAdapterConfig)
            .AddScoped<IMapper, ServiceMapper>();

    private static IServiceCollection ConfigureHttpJsonOptions(this IServiceCollection services) =>
        services
            .ConfigureHttpJsonOptions(options =>
            {
                options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
            })
            .Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
}