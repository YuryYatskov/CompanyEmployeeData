using DataAccounting.Domain.Abstractions;

namespace DataAccounting.Domain.Models;

public class Wage : IEntity
{
    public int DepartmentId { get; set; }

    public int JobId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime DateOfWork { get; set; }

    public decimal Salary { get; set; }
}
