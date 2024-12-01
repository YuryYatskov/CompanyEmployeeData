namespace UserDataAccounting.Web.Models;

public class EmployeeModel
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; }
}

public record GetEmployeesResponse(IEnumerable<EmployeeModel> Employees);

public record GetEmployeeByIdResponse(EmployeeModel Employee);

public record CreateEmployeeRequest(string Name, string Phone, DateTime DateOfBirth, string Address);

public record CreateEmployeeResponse(int Id);

public record UpdateEmployeeRequest(int Id, string Name, string Phone, DateTime DateOfBirth, string Address);

public record UpdateEmployeeResponse(int Id);

public record DeleteEmployeeResponse(int Id);
