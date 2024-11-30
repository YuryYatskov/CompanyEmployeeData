using BuildingBlocks.CQRS;
using DataAccounting.Application.Contracts;
using DataAccounting.Application.Exceptions;
using DataAccounting.Domain.Models;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace DataAccounting.Application.Features.Employees.Commands;

public class UpdateEmployeeCommand : ICommand<Employee>
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; }
}

public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator()
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

public class UpdateEmployeeCommandHandler(
    IApplicationDbContext dbContext,
    ILogger<UpdateEmployeeCommandHandler> logger)
    : ICommandHandler<UpdateEmployeeCommand, Employee>
{
    public async Task<Employee> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await dbContext.Employees
                    .FindAsync([request.Id], cancellationToken: cancellationToken);

        if (employee is null)
        {
            throw new EmployeeNotFoundException(request.Id);
        }

        employee.Update(
            request.Name,
            request.Address,
            request.Phone,
            request.DateOfBirth);

        dbContext.Employees.Update(employee);
        await dbContext.SaveChangesAsync(cancellationToken);

        logger.LogInformation("{message} {employeeId}", $"Employee {employee.Id} is successfully updated.", employee.Id);

        return employee;
    }
}
