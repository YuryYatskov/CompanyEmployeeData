using DataAccounting.Application.Features.Jobs.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DataAccounting.API.Endpoints;

public static class BuildJobApi
{
    public static IEndpointRouteBuilder JobApi(this IEndpointRouteBuilder builder)
    {
        builder.MapPost ("api/1.0/job",
            async ([FromBody, Required] CreateJobCommand command,
                    IMediator mediator) =>
            {
                var job = await mediator.Send(command);
                //var result = new { id = orderId };

                //return Results.Created($"/job/{result.id}", result);
                return job;
            })
        .Produces(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status404NotFound, typeof(string))
        .Produces(StatusCodes.Status400BadRequest, typeof(string));

        builder.MapPut("api/1.0/job",
            async ([FromBody, Required] UpdateJobCommand command,
                IMediator mediator) =>
            {
                var job = await mediator.Send(command);
                //var result = new { id = orderId };

                //return Results.Created($"/job/{result.id}", result);
                return job;
            })
        .Produces(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status404NotFound, typeof(string))
        .Produces(StatusCodes.Status400BadRequest, typeof(string));

        builder.MapDelete("api/1.0/job",
            async ([FromBody, Required] DeleteJobCommand command,
                IMediator mediator) =>
            {
                var job = await mediator.Send(command);
                //var result = new { id = orderId };

                //return Results.Created($"/job/{result.id}", result);
                return job;
            })
        .Produces(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status404NotFound, typeof(string))
        .Produces(StatusCodes.Status400BadRequest, typeof(string));

        return builder;
    }
}
