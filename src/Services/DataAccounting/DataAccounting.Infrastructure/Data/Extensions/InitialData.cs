using DataAccounting.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccounting.Infrastructure.Data.Extensions;

internal class InitialData
{
    public static IEnumerable<Company> Companys =>
        new List<Company>
        {
        
        };

    public static IEnumerable<Department> Departments =>
        new List<Department>
        {
            Department.Create("Sales"),
            Department.Create("Marketing"),
            Department.Create("Accounts"),
            Department.Create("Administration"),
            Department.Create("Admin"),
            Department.Create("Education"),
            Department.Create("IT"),
            Department.Create("Human Resources")
        };

    public static IEnumerable<Job> Jobs =>
        new List<Job>
        {
            
        };

    public static IEnumerable<Employee> Employees =>
        new List<Employee>
        {

        };

    public static IEnumerable<Wage> Wages =>
        new List<Wage>
        {

        };
}
