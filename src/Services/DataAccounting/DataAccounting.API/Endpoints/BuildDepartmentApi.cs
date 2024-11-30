using DataAccounting.Application.Features.Departments.Commands;
using DataAccounting.Application.Features.Departments.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DataAccounting.API.Endpoints;

public static class BuildDepartmentApi
{
    public record DepartmentIdResponse(int Id);

    public static IEndpointRouteBuilder DepartmentApi(this IEndpointRouteBuilder builder)
    {
        const string RouteName = "api/1.0/department";
        
        builder.MapGet($"{RouteName}s",
            async ([AsParameters] GetDepartmentsQuery query,
                    IMediator mediator) =>
            {
                var response = await mediator.Send(query);
                return Results.Ok(response);

            })
        .WithName("GetDepartments")
        .Produces<GetDepartmentsResponse>(StatusCodes.Status200OK)
        .WithSummary("Get departments")
        .WithDescription("Get departments");

        builder.MapGet(RouteName + "/{id}", async (int id, IMediator mediator) =>
        {
            var response = await mediator.Send(new GetDepartmentQueryById(id));

            return Results.Ok(response);
        })
        .WithName("GetDepartmentById")
        .Produces<GetDepartmentByIdResponse>(StatusCodes.Status200OK)
        .WithSummary("Get department by id")
        .WithDescription("Get department by id");

        builder.MapPost (RouteName,
            async ([FromBody, Required] CreateDepartmentCommand command,
                    IMediator mediator) =>
            {
                var department = await mediator.Send(command);
                return Results.Created($"{RouteName}/{department.Id}", new DepartmentIdResponse(department.Id));
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
                return Results.Ok(new DepartmentIdResponse(department.Id));
            })
        .WithName("UpdateDepartment")
        .Produces(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update department")
        .WithDescription("Update department");

        builder.MapDelete(RouteName + "/{id}", async(int id, IMediator mediator) =>
            {
                var department = await mediator.Send(new DeleteDepartmentCommand(id));
                return Results.Ok(new DepartmentIdResponse(department.Id));
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
