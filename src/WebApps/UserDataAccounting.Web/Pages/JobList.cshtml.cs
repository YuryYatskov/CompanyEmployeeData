using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserDataAccounting.Web.Models;
using UserDataAccounting.Web.Services;

namespace UserDataAccounting.Web.Pages;

public class JobListModel(
    IJobService jobService,
    ILogger<JobListModel> logger)
        : PageModel
{
    public IEnumerable<JobModel> JobList { get; set; } = [];

    public async Task<IActionResult> OnGetAsync()
    {
        var response = await jobService.GetJobs();

        JobList = response.Jobs;

        return Page();
    }

    public async Task<IActionResult> OnPostDeleteJobAsync(int id)
    {
        logger.LogInformation("Delete job");

        await jobService.DeleteJob(id);

        return RedirectToPage("JobList");
    }
}
