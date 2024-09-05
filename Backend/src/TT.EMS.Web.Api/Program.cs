using Serilog;
using TT.EMS.Infrastructure.Extension;
using TT.EMS.Application.Extensions;
using TT.EMS.Web.Api.Extensions;
using TT.EMS.Web.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Host
    .UseSerilog((context, configuration) =>
        configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

app
    .UseSerilogRequestLogging();

app
    .RegisterEmployeeEndpoints();

app
    .UseDeveloperExceptionPage()
    .UseSwagger()
    .UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "QuotationApp.Web.Api v1");
    });

app.Run();
