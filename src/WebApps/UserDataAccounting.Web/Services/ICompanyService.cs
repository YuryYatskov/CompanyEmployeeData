using Refit;
using UserDataAccounting.Web.Models;

namespace UserDataAccounting.Web.Services;

public interface ICompanyService
{
    const string RouteName = "api/1.0/company";

    [Get(RouteName + "/{id}")]
    Task<GetCompanyByIdResponse> GetCompanyById(int id);
}
