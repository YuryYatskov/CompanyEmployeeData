using BuildingBlocks.CQRS;
using DataAccounting.Application.Contracts;
using DataAccounting.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccounting.Application.Features.Wages.Queries;

public record GetWagesParametersQuery : IQuery<GetWagesParametersResponse>;

public record GetWagesParametersResponse(
    List<Department> Departments,
    List<Job> Jobs,
    List<Employee> Employees);

public class GetWagesParametersQueryHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetWagesParametersQuery, GetWagesParametersResponse>
{
    public async Task<GetWagesParametersResponse> Handle(GetWagesParametersQuery request, CancellationToken cancellationToken)
    {
        var departments = await dbContext.Departments.ToListAsync(cancellationToken);
        var jobs = await dbContext.Jobs.ToListAsync(cancellationToken);
        var employees = await dbContext.Employees
            .Select(x => new Employee 
            {
                Name = x.Name,
                Id = x.Id
            })
            .ToListAsync(cancellationToken);

        return new GetWagesParametersResponse(departments, jobs, employees);
    }
}