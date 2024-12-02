using BuildingBlocks.CQRS;
using DataAccounting.Application.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccounting.Application.Features.Wages.Queries;

public record GetWagesQueryFilter(string Filter) : IQuery<GetWagesResponse>;

public class GetWagesQueryFilterHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetWagesQueryFilter, GetWagesResponse>
{
    public async Task<GetWagesResponse> Handle(GetWagesQueryFilter request, CancellationToken cancellationToken)
    {
        var filter = request.Filter;

        var wages = await dbContext.Wages
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
        .Where(x => x.DepartmentName.Contains(filter) || x.JobName.Contains(filter) || x.EmployeeName.Contains(filter) || x.Phone.Contains(filter))
        .Select(x => new WagesResponse(x.DepartmentId, x.DepartmentName, x.JobId, x.JobName, x.EmployeeId, x.EmployeeName, x.Phone, x.DateOfBirth, x.Address, x.DateOfWork, x.Salary))
        .ToListAsync(cancellationToken);

        return new GetWagesResponse(wages);
    }
}
