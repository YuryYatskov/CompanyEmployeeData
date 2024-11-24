using DataAccounting.Domain.Abstractions;

namespace DataAccounting.Domain.Models;

public class Company : IEntity<int>
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}
