using DataAccounting.Application.Contracts;
using DataAccounting.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccounting.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Company> Companys => Set<Company>();

    public DbSet<Department> Departments => Set<Department>();

    public DbSet<Job> Jobs => Set<Job>();

    public DbSet<Employee> Employees => Set<Employee>();

    public DbSet<Wage> Wages => Set<Wage>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
