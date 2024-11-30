using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserDataAccounting.Web.Models;
using UserDataAccounting.Web.Services;

namespace UserDataAccounting.Web.Pages;

public class EmployeeListModel(
    IEmployeeService employeeService,
    ILogger<EmployeeListModel> logger)
        : PageModel
{
    public IEnumerable<EmployeeModel> EmployeeList { get; set; } = [];

    public async Task<IActionResult> OnGetAsync()
    {
        var response = await employeeService.GetEmployees();

        EmployeeList = response.Employees;

        return Page();
    }

    public async Task<IActionResult> OnPostDeleteEmployeeAsync(int id)
    {
        logger.LogInformation("Delete employee");

        await employeeService.DeleteEmployee(id);

        return RedirectToPage("EmployeeList");
    }
}
