namespace UserDataAccounting.Web.Models;

public class WageModel
{
    public int DepartmentId { get; set; }

    public int JobId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime DateOfWork { get; set; }

    public decimal Salary { get; set; }
}
 
public record GetWagesResponse(IEnumerable<WageModel> Wages);

public record GetWageByIdResponse(WageModel Wage);

public record CreateWageRequest(int DepartmentId, int JobId, int EmployeeId, DateTime DateOfWork, decimal Salary);

public record CreateWageResponse(int DepartmentId, int JobId, int EmployeeId, DateTime DateOfWork);

public record UpdateWageRequest(int DepartmentId, int JobId, int EmployeeId, DateTime DateOfWork, decimal Salary);

public record UpdateWageResponse(int DepartmentId, int JobId, int EmployeeId, DateTime DateOfWork);

public record DeleteWageResponse(int DepartmentId, int JobId, int EmployeeId, DateTime DateOfWork);
