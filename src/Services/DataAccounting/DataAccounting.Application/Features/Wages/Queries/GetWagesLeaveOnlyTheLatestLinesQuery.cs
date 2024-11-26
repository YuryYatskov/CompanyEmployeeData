using BuildingBlocks.CQRS;
using DataAccounting.Application.Contracts;
using DataAccounting.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccounting.Application.Features.Wages.Queries;

public record GetWagesOnlyTheLatestQuery : IQuery<GetWagesOnlyTheLatestResponse>;

public record GetWagesOnlyTheLatestResponse(List<Wage> Wagess);

public class GetWagesOnlyTheLatestQueryHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetWagesOnlyTheLatestQuery, GetWagesOnlyTheLatestResponse>
{
    public async Task<GetWagesOnlyTheLatestResponse> Handle(GetWagesOnlyTheLatestQuery request, CancellationToken cancellationToken)
    {
        var wages = await dbContext.Wages
            .GroupBy(x => new { x.EmployeeId })
            .Select(g => new
            {
                EmployeeId = g.Key.EmployeeId,
                DateOfWork = g.Max(row => row.DateOfWork)
            })
            .Join(dbContext.Wages,
                x => new { x.EmployeeId, x.DateOfWork },
                y => new { y.EmployeeId, y.DateOfWork },
                (x, y) => new Wage
                {
                    DepartmentId = y.DepartmentId,
                    JobId = y.JobId,
                    EmployeeId = x.EmployeeId,
                    DateOfWork = x.DateOfWork,
                    Salary = y.Salary,

                })
            .ToListAsync(cancellationToken);

        return new GetWagesOnlyTheLatestResponse(wages);
    }
}