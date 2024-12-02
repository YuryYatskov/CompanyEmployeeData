using BuildingBlocks.CQRS;
using DataAccounting.Application.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccounting.Application.Features.Wages.Queries;

public record GetWareMediumQuery : IQuery<GetMediumWagesResponse>;

public record MediumWagesResponse(int DepartmentId, string DepartmentName, decimal MediumSalary);

public record GetMediumWagesResponse(List<MediumWagesResponse> Wages);

public class CetWareMediumQueryHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetWareMediumQuery, GetMediumWagesResponse>
{
    public async Task<GetMediumWagesResponse> Handle(GetWareMediumQuery request, CancellationToken cancellationToken)
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
                (x, y) => new {
                    DepartmentId = y.DepartmentId,
                    Salary = y.Salary,
                    Numberoflines = 1
                })
            .GroupBy(x => new { x.DepartmentId })
            .Select(g => new
            {
                DepartmentId = g.Key.DepartmentId,
                //Salary = g.Sum(row => row.Salary),
                //Numberoflines = g.Sum(row => row.Numberoflines),
                MediumSalary = g.Sum(row => row.Salary) / g.Sum(row => row.Numberoflines)
            })
            .Join(dbContext.Departments,
                x => x.DepartmentId,
                y => y.Id,
            (x, y) => new MediumWagesResponse
            (
                x.DepartmentId,
                y.Name,
                x.MediumSalary
            ))
            .ToListAsync(cancellationToken);

        return new GetMediumWagesResponse(wages);
    }
}