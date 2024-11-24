using DataAccounting.Domain.Abstractions;

namespace DataAccounting.Domain.Models;

public class Department : Entity<int>
{
    public string Name { get; set; } = string.Empty;

    public static Department Create(string name)
    {
        Department department = new()
        {
            Name = name
        };

        return department;
    }

    public void Update(string name)
    {
        Name = name;
    }
}