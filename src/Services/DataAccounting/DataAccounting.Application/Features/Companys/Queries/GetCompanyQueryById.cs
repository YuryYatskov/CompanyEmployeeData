using BuildingBlocks.CQRS;
using DataAccounting.Application.Contracts;
using DataAccounting.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccounting.Application.Features.Companys.Queries;

public record GetCompanyQueryById(int Id) : IQuery<GetCompanyByIdResponse>;

public record GetCompanyByIdResponse(Company? Company);

public class GetCompanyQueryByIdHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetCompanyQueryById, GetCompanyByIdResponse>
{
    public async Task<GetCompanyByIdResponse> Handle(GetCompanyQueryById request, CancellationToken cancellationToken)
    {
        var company = await dbContext.Companys.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        return new GetCompanyByIdResponse(company);
    }
}