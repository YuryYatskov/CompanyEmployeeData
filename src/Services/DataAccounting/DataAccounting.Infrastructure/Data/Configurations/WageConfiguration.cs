using DataAccounting.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccounting.Infrastructure.Data.Configurations;

public class WageConfiguration : IEntityTypeConfiguration<Wage>
{
    public void Configure(EntityTypeBuilder<Wage> builder)
    {
        builder.HasKey(c => new { c.DepartmentId, c.JobId, c.EmployeeId });

        builder.HasOne<Department>()
            .WithMany()
            .HasForeignKey(o => o.DepartmentId)
            .IsRequired();

        builder.HasOne<Job>()
            .WithMany()
            .HasForeignKey(o => o.JobId)
            .IsRequired();

        builder.HasOne<Employee>()
            .WithMany()
            .HasForeignKey(o => o.EmployeeId)
            .IsRequired();

        builder.Property(c => c.DateOfWork).IsRequired();

        builder.Property(c => c.Salary);
    }
}