using DataAccounting.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccounting.Infrastructure.Data.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Name).HasMaxLength(100).IsRequired();

        builder.Property(c => c.Address).HasMaxLength(200);

        builder.Property(c => c.Phone).HasMaxLength(12);

        builder.Property(c => c.DateOfBirth);

        builder.HasIndex(e => e.Name);
    }
}