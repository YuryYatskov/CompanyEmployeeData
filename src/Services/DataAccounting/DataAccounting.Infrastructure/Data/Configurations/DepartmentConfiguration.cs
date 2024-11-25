using DataAccounting.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccounting.Infrastructure.Data.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Name).HasMaxLength(50).IsRequired();

        builder.HasIndex(e => e.Name);
    }
}
