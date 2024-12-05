using BuildingBlocks.CQRS;
using DataAccounting.Application.Contracts;
using DataAccounting.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccounting.Application.Features.Wages.Queries;

public record GetWareEmployeeQuery : IQuery<GetEmployeesWagesResponse>;

public record GetEmployeesWagesResponse(List<WagesResponse> Wages);

public class GetWareEmployeeQueryHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetWareEmployeeQuery, GetEmployeesWagesResponse>
{
    public async Task<GetEmployeesWagesResponse> Handle(
        GetWareEmployeeQuery request, CancellationToken cancellationToken)
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
            .ToListAsync(cancellationToken);

        var employees = await dbContext.Employees.ToListAsync(cancellationToken);

        var employeesWages = employees
            .GroupJoin(
                wages,
                e => e.Id,
                w => w.EmployeeId,
                (e, subgroup) => new { e, subgroup })
            .SelectMany(
                joinedSet => joinedSet.subgroup.DefaultIfEmpty(),
            (employee, wage) => new WagesResponse
            (
                wage == null ? 0 : wage.DepartmentId,
                wage == null ? string.Empty : wage.DepartmentName,
                wage == null ? 0 : wage.JobId,
                wage == null ? string.Empty : wage.JobName,
                employee.e.Id,
                employee.e.Name,
                employee.e.Phone,
                employee.e.DateOfBirth,
                employee.e.Address,
                wage == null ? new DateTime() : wage.DateOfWork,
                wage == null ? 0m : wage.Salary
                ))
            .ToList();

        return new GetEmployeesWagesResponse(employeesWages); 
    }
}
