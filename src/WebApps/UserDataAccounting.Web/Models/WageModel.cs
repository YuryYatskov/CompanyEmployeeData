namespace UserDataAccounting.Web.Models;

public class WageModel
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = default!;

    public int JobId { get; set; }

    public string JobName { get; set; } = default!;

    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } = default!;

    public string Phone { get; set; } = default!;

    public DateTime DateOfBirth { get; set; }

    string Address { get; set; } = default!;

    public DateTime DateOfWork { get; set; }

    public decimal Salary { get; set; }
}
 
public record GetWagesResponse(IEnumerable<WageModel> Wages);

public record GetWageByIdResponse(WageModel Wage);

public record CreateWageRequest(int DepartmentId, int JobId, int EmployeeId, DateTime DateOfWork, decimal Salary);

public record CreateWageResponse(int DepartmentId, int JobId, int EmployeeId, DateTime DateOfWork);

public record UpdateWageRequest(int DepartmentId, int JobId, int EmployeeId, DateTime DateOfWork, decimal Salary);

public record UpdateWageResponse(int DepartmentId, int JobId, int EmployeeId, DateTime DateOfWork);

public record DeleteWageRequest(int DepartmentId, int JobId, int EmployeeId, string DateOfWork);

public record DeleteWageResponse(int DepartmentId, int JobId, int EmployeeId, DateTime DateOfWork);

public record GetWagesParametersResponse(
    List<DepartmentModel> Departments,
    List<JobModel> Jobs,
    List<EmployeeModel> Employees);