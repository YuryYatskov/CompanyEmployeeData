using BuildingBlocks.CQRS;
using DataAccounting.Application.Contracts;
using DataAccounting.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccounting.Application.Features.Departments.Queries;

public record GetDepartmentsQuery : IQuery<GetDepartmentsResponse>;

public record GetDepartmentsResponse(List<Department> Departments);

public class GetDepartmentsQueryHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetDepartmentsQuery, GetDepartmentsResponse>
{
    public async Task<GetDepartmentsResponse> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
    {
        var departments = await dbContext.Departments.ToListAsync(cancellationToken);
        return new GetDepartmentsResponse(departments);
    }
}
