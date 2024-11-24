using DataAccounting.Domain.Abstractions;

namespace DataAccounting.Domain.Models;

public class Job : IEntity<int>
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
}
