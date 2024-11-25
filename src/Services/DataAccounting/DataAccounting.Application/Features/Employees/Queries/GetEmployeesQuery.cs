using BuildingBlocks.CQRS;
using DataAccounting.Application.Contracts;
using DataAccounting.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccounting.Application.Features.Employees.Queries;

public record GetEmployeesQuery : IQuery<GetEmployeesResponse>;

public record GetEmployeesResponse(List<Employee> Employeess);

public class GetEmployeesQueryHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetEmployeesQuery, GetEmployeesResponse>
{
    public async Task<GetEmployeesResponse> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await dbContext.Employees.ToListAsync(cancellationToken);
        return new GetEmployeesResponse(employees);
    }
}
