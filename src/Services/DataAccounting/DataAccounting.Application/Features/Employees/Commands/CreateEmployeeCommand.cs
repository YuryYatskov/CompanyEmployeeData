using BuildingBlocks.CQRS;
using DataAccounting.Application.Contracts;
using DataAccounting.Domain.Models;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace DataAccounting.Application.Features.Employees.Commands;

public class CreateEmployeeCommand : ICommand<Employee>
{
    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; }
}

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(p => p.Name)
          .NotEmpty().WithMessage("{Name} is required.")
          .NotNull()
          .MinimumLength(2).WithMessage("{Name} must be longer than 2 characters.")
          .MaximumLength(50).WithMessage("{Name} must not exceed 100 characters.");

        RuleFor(p => p.Address)
          .NotEmpty().WithMessage("{Address} is required.")
          .NotNull()
          .MinimumLength(2).WithMessage("{Address} must be longer than 2 characters.")
          .MaximumLength(200).WithMessage("{Address} must not exceed 200 characters.");

        RuleFor(p => p.Phone)
          .NotEmpty().WithMessage("{Phone} is required.")
          .NotNull()
          .MinimumLength(11).WithMessage("{Phone} must be longer than 11 characters.")
          .MaximumLength(12).WithMessage("{Phone} must not exceed 12 characters.");

        RuleFor(p => p.DateOfBirth)
            .NotEmpty()
            .Must(date => date != default(DateTime)).WithMessage("Date of birth is required");
    }
}

public class CreateEmployeeCommandHandler(
    IApplicationDbContext dbContext,
    ILogger<CreateEmployeeCommandHandler> logger)
    : ICommandHandler<CreateEmployeeCommand, Employee>
{
    public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = Employee.Create(
            request.Name,
            request.Address,
            request.Phone,
            request.DateOfBirth);

        dbContext.Employees.Add(employee);
        await dbContext.SaveChangesAsync(cancellationToken);

        logger.LogInformation("{message} {employeeId}", $"Employee {employee.Id} is successfully created.", employee.Id);

        return employee;
    }
}
