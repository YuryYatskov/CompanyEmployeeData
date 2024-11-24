using DataAccounting.Domain.Abstractions;

namespace DataAccounting.Domain.Models;

public class Job : Entity<int>
{
    public string Name { get; set; } = string.Empty;
}
