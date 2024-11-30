using Refit;
using UserDataAccounting.Web.Models;

namespace UserDataAccounting.Web.Services;

public interface IJobService
{
    const string RouteName = "/api/1.0/job";

    [Get($"{RouteName}s")]
    Task<GetJobsResponse> GetJobs();

    [Get(RouteName + "/{id}")]
    Task<GetJobByIdResponse> GetJobById(int id);

    [Post(RouteName)]
    Task<CreateJobResponse> CreateJob(CreateJobRequest request);

    [Put(RouteName)]
    Task<UpdateJobResponse> UpdateJob(UpdateJobRequest request);

    [Delete(RouteName + "/{id}")]
    Task<DeleteJobResponse> DeleteJob(int id);
}
