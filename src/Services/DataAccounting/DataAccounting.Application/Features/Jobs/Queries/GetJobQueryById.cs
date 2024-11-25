using BuildingBlocks.CQRS;
using DataAccounting.Application.Contracts;
using DataAccounting.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccounting.Application.Features.Jobs.Queries;

public record GetJobQueryById(int Id) : IQuery<GetJobByIdResponse>;

public record GetJobByIdResponse(Job? Job);

public class GetJobQueryByIdHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetJobQueryById, GetJobByIdResponse>
{
    public async Task<GetJobByIdResponse> Handle(GetJobQueryById request, CancellationToken cancellationToken)
    {
        var jod = await dbContext.Jobs.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        return new GetJobByIdResponse(jod);
    }
}
