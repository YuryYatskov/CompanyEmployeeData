using DataAccounting.Application.Features.Jobs.Commands;
using DataAccounting.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DataAccounting.API.Endpoints;

public static class BuildJobApi
{
    public static IEndpointRouteBuilder JobApi(this IEndpointRouteBuilder builder)
    {
        const string RouteName = "api/1.0/job";

        builder.MapPost (RouteName,
            async ([FromBody, Required] CreateJobCommand command,
                    IMediator mediator) =>
            {
                var job = await mediator.Send(command);
                return Results.Created($"{RouteName}/{job}", job);
            })
        .WithName("CreateJob")
        .Produces(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create job")
        .WithDescription("Create job");

        builder.MapPut(RouteName,
            async ([FromBody, Required] UpdateJobCommand command,
                IMediator mediator) =>
            {
                var job = await mediator.Send(command);
                return Results.Ok(job);
            })
        .WithName("UpdateJob")
        .Produces(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update job")
        .WithDescription("Update job");

        builder.MapDelete(RouteName,
            async ([FromBody, Required] DeleteJobCommand command,
                IMediator mediator) =>
            {
                var job = await mediator.Send(command);
                return Results.Ok(job);
            })
        .WithName("DeleteJob")
        .Produces(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Delete job")
        .WithDescription("Delete job");

        return builder;
    }
}
