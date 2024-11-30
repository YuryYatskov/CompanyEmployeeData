namespace UserDataAccounting.Web.Models;

public class DepartmentModel
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
}

public record GetDepartmentsResponse(IEnumerable<DepartmentModel> Departments);

public record  GetDepartmentByIdResponse(DepartmentModel Department);

public record CreateDepartmentRequest(string Name);

public record CreateDepartmentResponse(int Id);

public record UpdateDepartmentRequest(int Id, string Name);

public record UpdateDepartmentResponse(int Id);

public record DeleteDepartmentResponse(int Id);