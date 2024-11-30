using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserDataAccounting.Web.Models;
using UserDataAccounting.Web.Services;

namespace UserDataAccounting.Web.Pages;

public class EmployeeDetailModel(
    IEmployeeService employeeService,
    ILogger<EmployeeListModel> logger)
        : PageModel
{
    [BindProperty]
    public int Id { get; set; }

    [BindProperty]
    public string Name { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        if (id != 0)
        {
            var response = await employeeService.GetEmployeeById(id);

            Name = response!.Employee!.Name;
            Id = response!.Employee!.Id;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAddEmployeeAsync()
    {
        logger.LogInformation("Add employee");

        await employeeService.CreateEmployee(new CreateEmployeeRequest(Name));

        return RedirectToPage("EmployeeList");
    }

    public async Task<IActionResult> OnGetUpdateEmployeeAsync(int id)
    {
        var response = await employeeService.GetEmployeeById(id);
        Name = response!.Employee!.Name;
        Id = response!.Employee!.Id;

        return Page();
    }

    public async Task<IActionResult> OnPostUpdateEmployeeAsync()
    {
        logger.LogInformation("Updete employee");

        await employeeService.UpdateEmployee(new UpdateEmployeeRequest(Id, Name));

        return RedirectToPage("EmployeeList");
    }

    public IActionResult OnPostCancelEmployee()
    {
        return RedirectToPage("EmployeeList");
    }
}
