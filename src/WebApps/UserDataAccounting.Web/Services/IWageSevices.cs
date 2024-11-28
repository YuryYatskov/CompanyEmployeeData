using Refit;
using UserDataAccounting.Web.Models;

namespace UserDataAccounting.Web.Services;

public interface IWageSevices
{
    const string RouteName = "/api/1.0/wage";

    [Get($"{RouteName}s")]
    Task<GetWagesResponse> GetWages();

    //[Get(RouteName + "/{id}")]
    //Task<GetWageByIdResponse> GetWageById(int id);

    //[Post(RouteName)]
    //Task<CreateWageResponse> CreateWage(CreateWageRequest request);

    //[Put(RouteName)]
    //Task<UpdateWageResponse> UpdateWage(UpdateWageRequest request);

    //[Delete(RouteName + "/{departmentId}/{jobId}/{employeeId}/{dateOfWork}")]
    //Task<DeleteWageRequest> DeleteWage(bool request);
}
