using DataAccounting.Application.Features.Departments.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DataAccounting.API.Endpoints;

public static class BuildDepartmentApi
{
    public static IEndpointRouteBuilder DepartmentApi(this IEndpointRouteBuilder builder)
    {
        const string RouteName = "api/1.0/department";

        builder.MapPost (RouteName,
            async ([FromBody, Required] CreateDepartmentCommand command,
                    IMediator mediator) =>
            {
                var department = await mediator.Send(command);
                return Results.Created($"{RouteName}/{department}", department); 
            })
        .WithName("CreateDepartment")
        .Produces(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create department")
        .WithDescription("Create department");

        builder.MapPut(RouteName,
            async ([FromBody, Required] UpdateDepartmentCommand command,
                IMediator mediator) =>
            {
                var department = await mediator.Send(command);
                return Results.Ok(department);
            })
        .WithName("UpdateDepartment")
        .Produces(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update department")
        .WithDescription("Update department");

        builder.MapDelete(RouteName,
            async ([FromBody, Required] DeleteDepartmentCommand command,
                IMediator mediator) =>
            {
                var department = await mediator.Send(command);
                return Results.Ok(department);
            })
        .WithName("DeleteDepartment")
        .Produces(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Delete department")
        .WithDescription("Delete department");

        return builder;
    }
}
