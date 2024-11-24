using DataAccounting.Domain.Abstractions;

namespace DataAccounting.Domain.Models;

public class Company : Entity<int>
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}
