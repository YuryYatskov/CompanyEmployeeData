using DataAccounting.Application.Features.Employees.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DataAccounting.API.Endpoints;

public static class BuildEmployeeApi
{
    public static IEndpointRouteBuilder EmployeeApi(this IEndpointRouteBuilder builder)
    {
        const string RouteName = "api/1.0/employee";

        builder.MapPost (RouteName,
            async ([FromBody, Required] CreateEmployeeCommand command,
                    IMediator mediator) =>
            {
                var employee = await mediator.Send(command);
                return Results.Created($"{RouteName}/{employee}", employee);
            })
        .WithName("CreateEmployee")
        .Produces(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create employee")
        .WithDescription("Create employee");

        builder.MapPut(RouteName,
            async ([FromBody, Required] UpdateEmployeeCommand command,
                IMediator mediator) =>
            {
                var employee = await mediator.Send(command);
                return Results.Ok(employee);
            })
        .WithName("UpdateEmployee")
        .Produces(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update employee")
        .WithDescription("Update employee");

        builder.MapDelete(RouteName,
            async ([FromBody, Required] DeleteEmployeeCommand command,
                IMediator mediator) =>
            {
                var employee = await mediator.Send(command);
                return Results.Ok(employee);
            })
        .WithName("DeleteEmployee")
        .Produces(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Delete employee")
        .WithDescription("Delete employee");

        return builder;
    }
}
