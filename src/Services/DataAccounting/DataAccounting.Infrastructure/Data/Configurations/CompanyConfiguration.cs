using DataAccounting.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccounting.Infrastructure.Data.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Name).HasMaxLength(100).IsRequired();

        builder.Property(c => c.Description).HasMaxLength(10000);

        builder.HasIndex(e => e.Name);
    }
}
