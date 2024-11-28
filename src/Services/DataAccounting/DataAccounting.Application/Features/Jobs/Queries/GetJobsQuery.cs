using BuildingBlocks.CQRS;
using DataAccounting.Application.Contracts;
using DataAccounting.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccounting.Application.Features.Jobs.Queries;
public record GetJobsQuery : IQuery<GetJobsResponse>;

public record GetJobsResponse(List<Job> Jobs);

public class GetJobsQueryHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetJobsQuery, GetJobsResponse>
{
    public async Task<GetJobsResponse> Handle(GetJobsQuery request, CancellationToken cancellationToken)
    {
        var jobs = await dbContext.Jobs.ToListAsync(cancellationToken);
        return new GetJobsResponse(jobs);
    }
}

