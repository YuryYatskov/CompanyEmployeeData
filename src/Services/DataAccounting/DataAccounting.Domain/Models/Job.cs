using DataAccounting.Domain.Abstractions;

namespace DataAccounting.Domain.Models;

public class Job : Entity<int>
{
    public string Name { get; set; } = string.Empty;

    public static Job Create(string name)
    {
        Job job = new()
        {
            Name = name
        };

        return job;
    }

    public void Update(string name)
    {
        Name = name;
    }
}
