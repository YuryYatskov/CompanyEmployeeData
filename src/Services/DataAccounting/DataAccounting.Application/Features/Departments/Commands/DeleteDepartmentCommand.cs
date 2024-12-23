﻿using BuildingBlocks.CQRS;
using DataAccounting.Application.Contracts;
using DataAccounting.Application.Exceptions;
using DataAccounting.Domain.Models;
using Microsoft.Extensions.Logging;

namespace DataAccounting.Application.Features.Departments.Commands;

public class DeleteDepartmentCommand : ICommand<Department>
{
    public int Id { get; set; }

    public DeleteDepartmentCommand(int id)
    { 
        Id = id;
    }
}

public class DeleteDepartmentCommandHandler(
    IApplicationDbContext dbContext,
    ILogger<CreateDepartmentCommandHandler> logger)
    : ICommandHandler<DeleteDepartmentCommand, Department>
{
    public async Task<Department> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = await dbContext.Departments
            .FindAsync([request.Id], cancellationToken: cancellationToken);

        if (department is null)
        {
            throw new DepartmentNotFoundException(request.Id);
        }

        dbContext.Departments.Remove(department);
        await dbContext.SaveChangesAsync(cancellationToken);
        
        logger.LogInformation("{message} {departmentId}", $"Department {department.Id} is successfully deleted.", department.Id);

        return department;
    }
}
