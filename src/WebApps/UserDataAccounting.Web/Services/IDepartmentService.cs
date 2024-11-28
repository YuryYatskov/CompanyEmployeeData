using Refit;
using UserDataAccounting.Web.Models;

namespace UserDataAccounting.Web.Services;

public interface IDepartmentService
{
    const string RouteName = "/api/1.0/department";

    [Get($"{RouteName}s")]
    Task<GetDepartmentsResponse> GetDepartments();

    [Get(RouteName + "/{id}")]
    Task<GetDepartmentByIdResponse> GetDepartmentById(int id);

    [Post(RouteName)]
    Task<CreateDepartmentResponse> CreateDepartment(CreateDepartmentRequest request);

    [Put(RouteName)]
    Task<UpdateDepartmentResponse> UpdateDepartment(UpdateDepartmentRequest request);

    [Delete(RouteName + "/{id}")]
    Task<DeleteDepartmentRequest> DeleteDepartment(int id);
}
