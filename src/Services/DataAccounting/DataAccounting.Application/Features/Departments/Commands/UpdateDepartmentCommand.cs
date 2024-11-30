using BuildingBlocks.CQRS;
using DataAccounting.Application.Contracts;
using DataAccounting.Application.Exceptions;
using DataAccounting.Domain.Models;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace DataAccounting.Application.Features.Departments.Commands;

public class UpdateDepartmentCommand : ICommand<Department>
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
}

public class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
{
    public UpdateDepartmentCommandValidator()
    {
        RuleFor(p => p.Name)
          .NotEmpty().WithMessage("{Name} is required.")
          .NotNull()
          .MinimumLength(2).WithMessage("{Name} must be longer than 2 characters.")
          .MaximumLength(50).WithMessage("{Name} must not exceed 50 characters.");
    }
}

public class UpdateDepartmentCommandHandler(
    IApplicationDbContext dbContext,
    ILogger<CreateDepartmentCommandHandler> logger)
    : ICommandHandler<UpdateDepartmentCommand, Department>
{
    public async Task<Department> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = await dbContext.Departments
            .FindAsync([request.Id], cancellationToken: cancellationToken);

        if (department is null)
        {
            throw new DepartmentNotFoundException(request.Id);
        }

        department.Update(request.Name);

        dbContext.Departments.Update(department);
        await dbContext.SaveChangesAsync(cancellationToken);

        logger.LogInformation("{message} {departmentId}", $"Department {department.Id} is successfully updated.", department.Id);

        return department;
    }
}
