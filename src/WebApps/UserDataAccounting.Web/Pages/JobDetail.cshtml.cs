using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserDataAccounting.Web.Models;
using UserDataAccounting.Web.Services;

namespace UserDataAccounting.Web.Pages;

public class JobDetailModel(
    IJobService jobService,
    ILogger<JobListModel> logger)
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
            var response = await jobService.GetJobById(id);
            //Job = response.Job;
            Name = response!.Job!.Name;
            Id = response!.Job!.Id;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAddJobAsync()
    {
        logger.LogInformation("Add job");

        await jobService.CreateJob(new CreateJobRequest(Name));

        return RedirectToPage("JobList");
    }

    public async Task<IActionResult> OnGetUpdateJobAsync(int id)
    {
        var response = await jobService.GetJobById(id);
        Name = response!.Job!.Name;
        Id = response!.Job!.Id;

        return Page();
    }

    public async Task<IActionResult> OnPostUpdateJobAsync()
    {
        logger.LogInformation("Updete job");

        await jobService.UpdateJob(new UpdateJobRequest(Id, Name));

        return RedirectToPage("JobList");
    }

    public IActionResult OnPostCancelJob()
    {
        return RedirectToPage("JobList");
    }
}
