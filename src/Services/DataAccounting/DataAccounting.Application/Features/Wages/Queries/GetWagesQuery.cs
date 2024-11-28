using BuildingBlocks.CQRS;
using DataAccounting.Application.Contracts;
using DataAccounting.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccounting.Application.Features.Wages.Queries;

public record GetWagesQuery : IQuery<GetWagesResponse>;

public record GetWagesResponse(List<Wage> Wages);

public class GetWagesQueryHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetWagesQuery, GetWagesResponse>
{
    public async Task<GetWagesResponse> Handle(GetWagesQuery request, CancellationToken cancellationToken)
    {
        var wages = await dbContext.Wages.ToListAsync(cancellationToken);
        return new GetWagesResponse(wages);
    }
}
