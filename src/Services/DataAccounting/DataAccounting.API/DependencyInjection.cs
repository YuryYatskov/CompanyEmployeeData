using BuildingBlocks.Builders;
using BuildingBlocks.Exceptions.Handler;
using DataAccounting.API.Endpoints;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using System.Reflection;

namespace DataAccounting.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration, string nameService)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwagger(nameService);
        
        services.AddExceptionHandler<CustomExceptionHandler>();
        services.AddHealthChecks()
            .AddSqlServer(configuration.GetConnectionString("Database")!);

        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app, string nameService)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{nameService} v1"));
        }

        app.UseExceptionHandler(options => { });
        app.UseHealthChecks("/health",
            new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

        app.MapGet("api/version", () =>
        {
            return Assembly
              .GetExecutingAssembly()
              .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
              ?.InformationalVersion;
        })
        .WithName("Version")
        .WithSummary("Version")
        .WithDescription("Version");

        app.DepartmentApi();
        app.JobApi();
        app.EmployeeApi();
        app.WageApi();

        return app;
    }
}
