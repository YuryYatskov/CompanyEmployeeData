using DataAccounting.Application.Features.Wages.Commands;
using DataAccounting.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DataAccounting.API.Endpoints;

public static class BuildWageApi
{
    public static IEndpointRouteBuilder WageApi(this IEndpointRouteBuilder builder)
    {
        const string RouteName = "api/1.0/wage";

        builder.MapPost (RouteName,
            async ([FromBody, Required] CreateWageCommand command,
                    IMediator mediator) =>
            {
                var wage = await mediator.Send(command);
                return Results.Created($"{RouteName}/{wage}", wage);
            })
        .WithName("CreateWage")
        .Produces(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create wage")
        .WithDescription("Create wage");

        builder.MapPut(RouteName,
            async ([FromBody, Required] UpdateWageCommand command,
                IMediator mediator) =>
            {
                var wage = await mediator.Send(command);
                return Results.Ok(wage);
            })
        .WithName("UpdateWage")
        .Produces(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update wage")
        .WithDescription("Update wage");

        builder.MapDelete(RouteName,
            async ([FromBody, Required] DeleteWageCommand command,
                IMediator mediator) =>
            {
                var wage = await mediator.Send(command);
                return Results.Ok(wage);
            })
        .WithName("DeleteWage")
        .Produces(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Delete wage")
        .WithDescription("Delete wage");

        return builder;
    }
}
