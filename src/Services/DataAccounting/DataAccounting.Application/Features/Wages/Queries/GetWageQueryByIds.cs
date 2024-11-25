using BuildingBlocks.CQRS;
using DataAccounting.Application.Contracts;
using DataAccounting.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccounting.Application.Features.Wages.Queries;

public record GetWageQueryById(
    int DepartmentId,
    int JobId,
    int EmployeeId,
    DateTime DateOfWork) 
    : IQuery<GetWageByIdResponse>;

public record GetWageByIdResponse(Wage? Wage);

public class GetWageQueryByIdHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetWageQueryById, GetWageByIdResponse>
{
    public async Task<GetWageByIdResponse> Handle(GetWageQueryById request, CancellationToken cancellationToken)
    {
        var wage = await dbContext.Wages.FirstOrDefaultAsync(x 
            => x.DepartmentId == request.DepartmentId
            && x.JobId == request.JobId
            && x.EmployeeId == request.EmployeeId
            && x.DateOfWork == request.DateOfWork
            , cancellationToken);

        return new GetWageByIdResponse(wage);
    }
}
