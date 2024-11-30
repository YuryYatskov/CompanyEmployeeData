using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserDataAccounting.Web.Models;
using UserDataAccounting.Web.Services;

namespace UserDataAccounting.Web.Pages;

public class DepartmentListModel(
    IDepartmentService departmentService,
    ILogger<DepartmentListModel> logger)
        : PageModel
{
    public IEnumerable<DepartmentModel> DepartmentList { get; set; } = [];

    public async Task<IActionResult> OnGetAsync()
    {
        var response = await departmentService.GetDepartments();

            DepartmentList = response.Departments;

        return Page();
    }

    public async Task<IActionResult> OnPostDeleteDepartmentAsync(int id)
    {
        logger.LogInformation("Delete department");

        await departmentService.DeleteDepartment(id);

        return RedirectToPage("DepartmentList");
    }
}
