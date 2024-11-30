using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserDataAccounting.Web.Models;
using UserDataAccounting.Web.Services;

namespace UserDataAccounting.Web.Pages;

public class DepartmentDetailModel(
    IDepartmentService departmentService,
    ILogger<DepartmentListModel> logger)
        : PageModel
{
    [BindProperty]
    public int Id { get; set; }

    [BindProperty]
    public string Name { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        if(id != 0)
        { 
            var response = await departmentService.GetDepartmentById(id);
            //Department = response.Department;
            Name = response!.Department!.Name;
            Id = response!.Department!.Id;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAddDepartmentAsync()
    {
        logger.LogInformation("Add department");

        await departmentService.CreateDepartment(new CreateDepartmentRequest(Name));

        return RedirectToPage("DepartmentList");
    }

    public async Task<IActionResult> OnGetUpdateDepartmentAsync(int id)
    {
        var response = await departmentService.GetDepartmentById(id);
        Name = response!.Department!.Name;
        Id = response!.Department!.Id;

        return Page();
    }

    public async Task<IActionResult> OnPostUpdateDepartmentAsync()
    {
        logger.LogInformation("Updete department");

        await departmentService.UpdateDepartment(new UpdateDepartmentRequest(Id, Name));

        return RedirectToPage("DepartmentList");
    }

    public IActionResult OnPostCancelDepartment()
    {
        return RedirectToPage("DepartmentList");
    }
}
