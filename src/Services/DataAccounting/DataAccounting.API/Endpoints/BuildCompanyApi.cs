using DataAccounting.Application.Features.Companys.Queries;
using MediatR;

namespace DataAccounting.API.Endpoints;

public static class BuildCompanyApi
{
    public static IEndpointRouteBuilder CompanyApi(this IEndpointRouteBuilder builder)
    {
        const string RouteName = "api/1.0/company";

        builder.MapGet($"{RouteName}" + "/{id}", async (int id, IMediator mediator) =>
        {
            var response = await mediator.Send(new GetCompanyQueryById(id));

            return Results.Ok(response);
        })
        .WithName("GetCompanyById")
        .Produces<GetCompanyByIdResponse>(StatusCodes.Status200OK)
        .WithSummary("Get company by id")
        .WithDescription("Get company by id");

        return builder;
    }
}
