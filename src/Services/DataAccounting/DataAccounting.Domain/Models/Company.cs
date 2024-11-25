using DataAccounting.Domain.Abstractions;

namespace DataAccounting.Domain.Models;

public class Company : Entity<int>
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public static Company Create(string name, string description)
    {
        Company company = new()
        {
            Name = name,
            Description = description
        };

        return company;
    }

    public void Update(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
