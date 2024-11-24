using DataAccounting.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccounting.Application.Contracts;

public interface IApplicationDbContext
{
    DbSet<Company> Companys { get; }

    DbSet<Department> Departments { get; }

    DbSet<Job> Jobs { get; }

    DbSet<Employee> Employees { get; }

    DbSet<Wage> Wages { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
