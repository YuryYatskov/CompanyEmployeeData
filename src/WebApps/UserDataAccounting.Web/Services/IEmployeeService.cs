using Refit;
using UserDataAccounting.Web.Models;

namespace UserDataAccounting.Web.Services;

public interface IEmployeeService
{
    const string RouteName = "/api/1.0/employee";

    [Get($"{RouteName}s")]
    Task<GetEmployeesResponse> GetEmployees();

    [Get(RouteName + "/{id}")]
    Task<GetEmployeeByIdResponse> GetEmployeeById(int id);

    [Post(RouteName)]
    Task<CreateEmployeeResponse> CreateEmployee(CreateEmployeeRequest request);

    [Put(RouteName)]
    Task<UpdateEmployeeResponse> UpdateEmployee(UpdateEmployeeRequest request);

    [Delete(RouteName + "/{id}")]
    Task<DeleteEmployeeResponse> DeleteEmployee(int id);
}
