using Microsoft.AspNetCore.Mvc.RazorPages;
using UserDataAccounting.Web.Models;
using UserDataAccounting.Web.Services;

namespace UserDataAccounting.Web.Pages;

public class IndexModel(
    ICompanyService companyService,
    ILogger<IndexModel> logger)
        : PageModel
{
    public CompanyModel Company { get; set; } = new();

    public async Task OnGetAsync()
    {
        var response = await companyService.GetCompanyById(1);

        Company = response.Company;
    }
}
