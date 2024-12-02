using BuildingBlocks.CQRS;
using DataAccounting.Application.Contracts;
using DataAccounting.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccounting.Application.Features.Wages.Queries;

public record GetWagesOnlyTheLatestQuery : IQuery<GetWagesOnlyTheLatestResponse>;

public record GetWagesOnlyTheLatestResponse(List<WagesResponse> Wages);

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
            .Join(dbContext.Departments,
                x => x.DepartmentId,
                y => y.Id,
                (x, y) => new
                {
                    x.DepartmentId,
                    DepartmentName = y.Name,
                    x.JobId,
                    x.EmployeeId,
                    x.DateOfWork,
                    x.Salary
                })
             .Join(dbContext.Jobs,
                x => x.JobId,
                y => y.Id,
                (x, y) => new
                {
                    x.DepartmentId,
                    x.DepartmentName,
                    x.JobId,
                    JobName = y.Name,
                    x.EmployeeId,
                    x.DateOfWork,
                    x.Salary
                })
            .Join(dbContext.Employees,
                x => x.EmployeeId,
                y => y.Id,
                (x, y) => new
                {
                    x.DepartmentId,
                    x.DepartmentName,
                    x.JobId,
                    x.JobName,
                    x.EmployeeId,
                    EmployeeName = y.Name,
                    y.Phone,
                    y.DateOfBirth,
                    y.Address,
                    x.DateOfWork,
                    x.Salary
                })
            .Select(x => new WagesResponse(x.DepartmentId, x.DepartmentName, x.JobId, x.JobName, x.EmployeeId, x.EmployeeName, x.Phone, x.DateOfBirth, x.Address, x.DateOfWork, x.Salary))
            .ToListAsync(cancellationToken);

        return new GetWagesOnlyTheLatestResponse(wages);
    }
}