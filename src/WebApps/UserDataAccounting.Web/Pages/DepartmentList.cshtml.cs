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
}
