using DataAccounting.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccounting.Infrastructure.Data.Configurations;

public class WageConfiguration : IEntityTypeConfiguration<Wage>
{
    public void Configure(EntityTypeBuilder<Wage> builder)
    {
        builder.HasKey(c => new { c.DepartmentId, c.JobId, c.EmployeeId, c.DateOfWork });

        builder.HasOne<Department>()
            .WithMany()
            .HasForeignKey(o => o.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne<Job>()
            .WithMany()
            .HasForeignKey(o => o.JobId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne<Employee>()
            .WithMany()
            .HasForeignKey(o => o.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.Property(c => c.DateOfWork).IsRequired();

        builder.Property(c => c.Salary).HasPrecision(12, 2);
    }
}