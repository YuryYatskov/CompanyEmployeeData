namespace UserDataAccounting.Web.Models;

public class JobModel
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
}

public record GetJobsResponse(IEnumerable<JobModel> Jobs);

public record GetJobByIdResponse(JobModel Job);

public record CreateJobRequest(string Name);

public record CreateJobResponse(int Id);

public record UpdateJobRequest(int Id, string Name);

public record UpdateJobResponse(int Id);

public record DeleteJobResponse(int Id);
