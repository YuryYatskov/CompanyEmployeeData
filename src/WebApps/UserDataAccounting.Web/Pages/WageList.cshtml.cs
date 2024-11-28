using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserDataAccounting.Web.Models;
using UserDataAccounting.Web.Services;

namespace UserDataAccounting.Web.Pages;

public class WageListModel(
    IWageSevices wageSevices,
    ILogger<WageListModel> logger)
        : PageModel
{
    public IEnumerable<WageModel> WageList { get; set; } = [];

    public async Task<IActionResult> OnGetAsync()
    {
        var response = await wageSevices.GetWages();

        WageList = response.Wages;

        return Page();
    }
}
