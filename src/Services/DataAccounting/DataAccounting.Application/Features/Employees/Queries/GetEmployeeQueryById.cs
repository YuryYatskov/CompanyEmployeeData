using BuildingBlocks.CQRS;
using DataAccounting.Application.Contracts;
using DataAccounting.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccounting.Application.Features.Employees.Queries;

public record GetEmployeeQueryById(int Id) : IQuery<GetEmployeeByIdResponse>;

public record GetEmployeeByIdResponse(Employee? Employee);

public class GetEmployeeQueryByIdHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetEmployeeQueryById, GetEmployeeByIdResponse>
{
    public async Task<GetEmployeeByIdResponse> Handle(GetEmployeeQueryById request, CancellationToken cancellationToken)
    {
        var employee = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        return new GetEmployeeByIdResponse(employee);
    }
}
