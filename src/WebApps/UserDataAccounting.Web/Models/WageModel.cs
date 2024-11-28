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

//public record GetWageByIdResponse(WageModel Wage);

//public record CreateWageRequest(string Name);

//public record CreateWageResponse(int Id);

//public record UpdateWageRequest(int Id, string Name);

//public record UpdateWageResponse(int Id);

//public record DeleteWageRequest(int DepartmentId, int JobId, int EmployeeId, DateTime DateOfWork);
