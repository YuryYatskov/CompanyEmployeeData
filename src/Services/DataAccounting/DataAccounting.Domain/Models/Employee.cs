using DataAccounting.Domain.Abstractions;

namespace DataAccounting.Domain.Models;

public class Employee : Entity<int>
{
    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; }
}
