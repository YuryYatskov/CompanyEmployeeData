using DataAccounting.Application.Features.Wages.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DataAccounting.API.Endpoints;

public static class BuildWageApi
{
    public static IEndpointRouteBuilder WageApi(this IEndpointRouteBuilder builder)
    {
        builder.MapPost ("api/1.0/wage",
            async ([FromBody, Required] CreateWageCommand command,
                    IMediator mediator) =>
            {
                var wage = await mediator.Send(command);
                //var result = new { id = orderId };

                //return Results.Created($"/wage/{result.id}", result);
                return wage;
            })
        .Produces(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status404NotFound, typeof(string))
        .Produces(StatusCodes.Status400BadRequest, typeof(string));

        builder.MapPut("api/1.0/wage",
            async ([FromBody, Required] UpdateWageCommand command,
                IMediator mediator) =>
            {
                var wage = await mediator.Send(command);
                //var result = new { id = orderId };

                //return Results.Created($"/wage/{result.id}", result);
                return wage;
            })
        .Produces(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status404NotFound, typeof(string))
        .Produces(StatusCodes.Status400BadRequest, typeof(string));

        builder.MapDelete("api/1.0/wage",
            async ([FromBody, Required] DeleteWageCommand command,
                IMediator mediator) =>
            {
                var wage = await mediator.Send(command);
                //var result = new { id = orderId };

                //return Results.Created($"/wage/{result.id}", result);
                return wage;
            })
        .Produces(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status404NotFound, typeof(string))
        .Produces(StatusCodes.Status400BadRequest, typeof(string));

        return builder;
    }
}
