using BuildingBlocks.CQRS;
using DataAccounting.Application.Contracts;
using DataAccounting.Domain.Models;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace DataAccounting.Application.Features.Departments.Commands;

public class CreateDepartmentCommand : ICommand<Department>
{
    public string Name { get; set; } = string.Empty;
}

public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
{
    public CreateDepartmentCommandValidator()
    {
        RuleFor(p => p.Name)
          .NotEmpty().WithMessage("{Name} is required.")
          .NotNull()
          .MinimumLength(2).WithMessage("{Name} must be longer than 2 characters.")
          .MaximumLength(50).WithMessage("{Name} must not exceed 50 characters.");
    }
}

public class CreateDepartmentCommandHandler(
    IApplicationDbContext dbContext,
    ILogger<CreateDepartmentCommandHandler> logger)
    : ICommandHandler<CreateDepartmentCommand, Department>
{
    public async Task<Department> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = Department.Create(request.Name);
        dbContext.Departments.Add(department);
        await dbContext.SaveChangesAsync(cancellationToken);

        logger.LogInformation("{message} {departmentId}", $"Department {department.Id} is successfully created.", department.Id);

        return department;
    }
}
