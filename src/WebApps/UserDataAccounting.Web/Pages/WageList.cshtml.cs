using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserDataAccounting.Web.Models;
using UserDataAccounting.Web.Services;

namespace UserDataAccounting.Web.Pages;

public class WageListModel(
    IWageService wageService,
    ILogger<WageListModel> logger)
        : PageModel
{
    public IEnumerable<WageModel> WageList { get; set; } = [];

    public async Task<IActionResult> OnGetAsync()
    {
        var response = await wageService.GetWages();

        WageList = response.Wages;

        return Page();
    }

    public async Task<IActionResult> OnPostDeleteWageAsync(int departmentId, int jobId, int employeeId, DateTime dateOfWork)
    {
        logger.LogInformation("Delete wage");

        var response = await wageService.DeleteWage(departmentId, jobId, employeeId, dateOfWork.ToString());

        return RedirectToPage("WageList");
    }
}
