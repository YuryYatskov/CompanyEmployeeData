using DataAccounting.Domain.Abstractions;
using System.Net;
using System.Numerics;
using System.Xml.Linq;

namespace DataAccounting.Domain.Models;

public class Wage : Entity
{
    public int DepartmentId { get; set; }

    public int JobId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime DateOfWork { get; set; }

    public decimal Salary { get; set; }

    public static Wage Create(
        int departmentId,
        int jobId,
        int employeeId,
        DateTime dateOfWork,
        decimal salary)
    {
        Wage wage = new()
        {
            DepartmentId = departmentId,
            JobId = jobId,
            EmployeeId = employeeId,
            DateOfWork = dateOfWork,
            Salary = salary
        };

        return wage;
    }

    public void Update(
        decimal salary)
    {
        Salary = salary;
    }
}
