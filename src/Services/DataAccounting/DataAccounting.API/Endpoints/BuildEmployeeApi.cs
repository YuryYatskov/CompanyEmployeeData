using DataAccounting.Application.Features.Employees.Commands;
using DataAccounting.Application.Features.Employees.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DataAccounting.API.Endpoints;

public static class BuildEmployeeApi
{
    public static IEndpointRouteBuilder EmployeeApi(this IEndpointRouteBuilder builder)
    {
        const string RouteName = "api/1.0/employee";

        builder.MapGet($"{RouteName}s",
        async ([AsParameters] GetEmployeesQuery query,
                IMediator mediator) =>
        {
            var response = await mediator.Send(query);
            return Results.Ok(response);

        })
        .WithName("GetEmployees")
        .Produces<GetEmployeesResponse>(StatusCodes.Status200OK)
        .WithSummary("Get employees")
        .WithDescription("Get employees");

        builder.MapGet(RouteName + "/{id}", async (int id, IMediator mediator) =>
        {
            var response = await mediator.Send(new GetEmployeeQueryById(id));

            return Results.Ok(response);
        })
        .WithName("GetEmployeeById")
        .Produces<GetEmployeeByIdResponse>(StatusCodes.Status200OK)
        .WithSummary("Get employee by id")
        .WithDescription("Get employee by id");

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

        builder.MapDelete(RouteName + "/{id}", async (int id, IMediator mediator) =>
            {
                var employee = await mediator.Send(new DeleteEmployeeCommand(id));
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
