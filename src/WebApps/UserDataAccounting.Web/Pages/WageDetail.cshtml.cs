using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserDataAccounting.Web.Models;
using UserDataAccounting.Web.Services;

namespace UserDataAccounting.Web.Pages;

public class WageDetailModel(
    IWageService wageService,
    IDepartmentService departmentService,
    ILogger<WageListModel> logger)
        : PageModel
{
    [BindProperty]
    public int DepartmentId { get; set; }

    [BindProperty]
    public string DepartmentName { get; set; } = default!;

    [BindProperty]
    public int JobId { get; set; }

    [BindProperty]
    public string JobName { get; set; } = default!;

    [BindProperty]
    public int EmployeeId { get; set; }

    [BindProperty]
    public string EmployeeName { get; set; } = default!;

    [BindProperty]
    public DateTime DateOfWork { get; set; }

    [BindProperty]
    public decimal Salary { get; set; }

    public List<SelectListItem> Departments { get; set; } = default!;

    public List<SelectListItem> Jobs { get; set; } = default!;

    public List<SelectListItem> Employees { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int departmentId, int jobId, int employeeId, DateTime dateOfWork)
    {
        if (departmentId != 0)
        {
            var response = await wageService.GetWageById(departmentId, jobId, employeeId, dateOfWork.ToString());

            DepartmentId = response.Wage.DepartmentId;
            DepartmentName = response.Wage.DepartmentName;
            JobId = response.Wage.JobId;
            JobName = response.Wage.JobName;
            EmployeeId = response.Wage.EmployeeId;
            EmployeeName = response.Wage.EmployeeName;
            DateOfWork = response.Wage.DateOfWork;
            Salary = response.Wage.Salary;
        }
        else
        {
            DateOfWork = DateTime.Now.Date;

            var parameters = await wageService.GetWagesParameters();

            Departments = parameters.Departments
                .Select(x => new SelectListItem 
                { 
                    Value = x.Id.ToString(),
                    Text = x.Name })
                .ToList();

            Jobs = parameters.Jobs
                 .Select(x => new SelectListItem
                 {
                     Value = x.Id.ToString(),
                     Text = x.Name
                 })
                 .ToList();

            Employees = parameters.Employees
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })
                .ToList();
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAddWageAsync()
    {
        logger.LogInformation("Add wage");

        await wageService.CreateWage(new CreateWageRequest(DepartmentId, JobId, EmployeeId, DateOfWork, Salary));

        return RedirectToPage("WageList");
    }

    public async Task<IActionResult> OnPostUpdateWageAsync()
    {
        logger.LogInformation("Updete wage");

        await wageService.UpdateWage(new UpdateWageRequest(DepartmentId, JobId, EmployeeId, DateOfWork, Salary));

        return RedirectToPage("WageList");
    }

    public IActionResult OnPostCancelWage()
    {
        return RedirectToPage("WageList");
    }
}

