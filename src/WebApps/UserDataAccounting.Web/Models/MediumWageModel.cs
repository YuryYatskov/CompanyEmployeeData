namespace UserDataAccounting.Web.Models;

public class MediumWageModel
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = default!;

    public decimal MediumSalary { get; set; }

    public decimal Salary { get; set; }
}

public record GetMediumWagesResponse(IEnumerable<MediumWageModel> Wages);