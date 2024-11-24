using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccounting.Infrastructure.Data.Extensions;

public static class DatabaseExtentions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        context.Database.MigrateAsync().GetAwaiter().GetResult();

        await SeedAsync(context);
    }

    private static async Task SeedAsync(ApplicationDbContext context)
    {
        await SeedCompanyAsync(context);
        await SeedDepartmentAsync(context);
        await SeedJobAsync(context);
        await SeedEmployeeAsync(context);
        await SeedWageAsync(context);
    }

    private static async Task SeedCompanyAsync(ApplicationDbContext context)
    {
        if (!await context.Companys.AnyAsync())
        {
            await context.Companys.AddRangeAsync(InitialData.Companys);
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedDepartmentAsync(ApplicationDbContext context)
    {
        if (!await context.Departments.AnyAsync())
        {
            await context.Departments.AddRangeAsync(InitialData.Departments);
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedJobAsync(ApplicationDbContext context)
    {
        if (!await context.Jobs.AnyAsync())
        {
            await context.Jobs.AddRangeAsync(InitialData.Jobs);
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedEmployeeAsync(ApplicationDbContext context)
    {
        if (!await context.Employees.AnyAsync())
        {
            await context.Employees.AddRangeAsync(InitialData.Employees);
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedWageAsync(ApplicationDbContext context)
    {
        if (!await context.Wages.AnyAsync())
        {
            await context.Wages.AddRangeAsync(InitialData.Wages);
            await context.SaveChangesAsync();
        }
    }
}

