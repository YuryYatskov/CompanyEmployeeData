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
    [BindProperty(SupportsGet = true)]
    public string? SearchString { get; set; }

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

    public async Task<IActionResult> OnPostPrintWageAsync()
    {
        var response = await wageService.GetWages();
        var wageList = response.Wages;
        string printWage = string.Join("\r\n", wageList.Select(x => $"{x.DepartmentId};{x.DepartmentName};{x.JobId};{x.JobName};{x.EmployeeId};{x.EmployeeName};{x.DateOfWork};{x.Salary}"));

        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "PrintWage.txt")))
        {
            outputFile.WriteLine(printWage);
        }

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostFilterWageAsync(string DepartmentName)
    {
        var response = await wageService.GetWageFilters(SearchString);
        WageList = response.Wages;

        return Page();
    }
}
