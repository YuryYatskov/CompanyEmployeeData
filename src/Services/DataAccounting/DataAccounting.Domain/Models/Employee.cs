using DataAccounting.Domain.Abstractions;

namespace DataAccounting.Domain.Models;

public class Employee : Entity<int>
{
    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; }

    public static Employee Create(
        string name,
        string address,
        string phone,
        DateTime dateOfBirth)
    {
        Employee employee = new()
        {
            Name = name,
            Address = address,
            Phone = phone,
            DateOfBirth = dateOfBirth
        };

        return employee;
    }

    public void Update(
        string name,
        string address,
        string phone,
        DateTime dateOfBirth)
    {
        Name = name;
        Address = address;
        Phone = phone;
        DateOfBirth = dateOfBirth;
    }
}
