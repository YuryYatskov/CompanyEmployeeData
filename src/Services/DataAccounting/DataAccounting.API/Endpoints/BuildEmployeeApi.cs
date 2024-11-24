using DataAccounting.Application.Features.Employees.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DataAccounting.API.Endpoints;

public static class BuildEmployeeApi
{
    public static IEndpointRouteBuilder EmployeeApi(this IEndpointRouteBuilder builder)
    {
        builder.MapPost ("api/1.0/employee",
            async ([FromBody, Required] CreateEmployeeCommand command,
                    IMediator mediator) =>
            {
                var employee = await mediator.Send(command);
                //var result = new { id = orderId };

                //return Results.Created($"/employee/{result.id}", result);
                return employee;
            })
        .Produces(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status404NotFound, typeof(string))
        .Produces(StatusCodes.Status400BadRequest, typeof(string));

        builder.MapPut("api/1.0/employee",
            async ([FromBody, Required] UpdateEmployeeCommand command,
                IMediator mediator) =>
            {
                var employee = await mediator.Send(command);
                //var result = new { id = orderId };

                //return Results.Created($"/employee/{result.id}", result);
                return employee;
            })
        .Produces(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status404NotFound, typeof(string))
        .Produces(StatusCodes.Status400BadRequest, typeof(string));

        builder.MapDelete("api/1.0/employee",
            async ([FromBody, Required] DeleteEmployeeCommand command,
                IMediator mediator) =>
            {
                var employee = await mediator.Send(command);
                //var result = new { id = orderId };

                //return Results.Created($"/employee/{result.id}", result);
                return employee;
            })
        .Produces(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status404NotFound, typeof(string))
        .Produces(StatusCodes.Status400BadRequest, typeof(string));

        return builder;
    }
}
