using DataAccounting.Application.Features.Wages.Commands;
using DataAccounting.Application.Features.Wages.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DataAccounting.API.Endpoints;

public static class BuildWageApi
{
    public record WageIdResponse(int DepartmentId, int JobId, int EmployeeId, DateTime DateOfWork);

    public static IEndpointRouteBuilder WageApi(this IEndpointRouteBuilder builder)
    {
        const string RouteName = "api/1.0/wage";

        builder.MapGet($"{RouteName}s",
        async ([AsParameters] GetWagesQuery query,
                IMediator mediator) =>
        {
            var response = await mediator.Send(query);
            return Results.Ok(response);

        })
        .WithName("GetWages")
        .Produces<GetWagesResponse>(StatusCodes.Status200OK)
        .WithSummary("Get wages")
        .WithDescription("Get wages");

        builder.MapGet($"{RouteName}s/onlyTheLatest",
        async ([AsParameters] GetWagesOnlyTheLatestQuery query,
                IMediator mediator) =>
        {
            var response = await mediator.Send(query);
            return Results.Ok(response);

        })
        .WithName("GetWagesOnlyTheLatest")
        .Produces<GetWagesOnlyTheLatestResponse>(StatusCodes.Status200OK)
        .WithSummary("Get wages only the latest")
        .WithDescription("Get wages  only the latest");

        builder.MapGet($"{RouteName}" + "/{departmentId}/{jobId}/{employeeId}/{dateOfWork}", async (
            int departmentId,
            int jobId,
            int employeeId,
            DateTime dateOfWork,
            IMediator mediator) =>
        {
            var response = await mediator.Send(new GetWageQueryById(departmentId, jobId, employeeId, dateOfWork));

            return Results.Ok(response);
        })
        .WithName("GetWageById")
        .Produces<GetWageByIdResponse>(StatusCodes.Status200OK)
        .WithSummary("Get wage by id")
        .WithDescription("Get wage by id");

        builder.MapPost (RouteName,
            async ([FromBody, Required] CreateWageCommand command,
                    IMediator mediator) =>
            {
                var wage = await mediator.Send(command);
                return Results.Created(RouteName, new WageIdResponse(wage.DepartmentId, wage.JobId, wage.EmployeeId, wage.DateOfWork));
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
                return Results.Ok(new WageIdResponse(wage.DepartmentId, wage.JobId, wage.EmployeeId, wage.DateOfWork));
            })
        .WithName("UpdateWage")
        .Produces(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update wage")
        .WithDescription("Update wage");

        builder.MapDelete(RouteName + "/{departmentId}/{jobId}/{employeeId}/{dateOfWork}", async (
            int departmentId,
            int jobId,
            int employeeId,
            DateTime dateOfWork,
            IMediator mediator) =>
            {
                var wage = await mediator.Send(new DeleteWageCommand(departmentId, jobId, employeeId, dateOfWork));
                return Results.Ok(new WageIdResponse(wage.DepartmentId, wage.JobId, wage.EmployeeId, wage.DateOfWork));
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
