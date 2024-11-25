using BuildingBlocks.CQRS;
using DataAccounting.Application.Contracts;
using DataAccounting.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccounting.Application.Features.Departments.Queries;

public record GetDepartmentQueryById(int Id) : IQuery<GetDepartmentByIdResponse>;

public record GetDepartmentByIdResponse(Department? Department);

public class GetDepartmentQueryByIdHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetDepartmentQueryById, GetDepartmentByIdResponse>
{
    public async Task<GetDepartmentByIdResponse> Handle(GetDepartmentQueryById request, CancellationToken cancellationToken)
    {
        var department = await dbContext.Departments.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        return new GetDepartmentByIdResponse(department);
    }
}
