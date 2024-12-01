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

    [BindProperty]
    public string Phone { get; set; } = default!;

    [BindProperty]
    public DateTime DateOfBirth { get; set; }

    [BindProperty]
    public string Address { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        if (id != 0)
        {
            var response = await employeeService.GetEmployeeById(id);

            Name = response!.Employee!.Name;
            Phone = response!.Employee!.Phone;
            DateOfBirth = response!.Employee!.DateOfBirth;
            Address = response!.Employee!.Address;
            Id = response!.Employee!.Id;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAddEmployeeAsync()
    {
        logger.LogInformation("Add employee");

        await employeeService.CreateEmployee(new CreateEmployeeRequest(Name, Phone, DateOfBirth, Address));

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

        await employeeService.UpdateEmployee(new UpdateEmployeeRequest(Id, Name, Phone, DateOfBirth, Address));

        return RedirectToPage("EmployeeList");
    }

    public IActionResult OnPostCancelEmployee()
    {
        return RedirectToPage("EmployeeList");
    }
}
