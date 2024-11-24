using BuildingBlocks.CQRS;
using DataAccounting.Application.Contracts;
using DataAccounting.Domain.Models;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace DataAccounting.Application.Features.Wages.Commands;

public class CreateWageCommand : ICommand<Wage>
{
    public int DepartmentId { get; set; }

    public int JobId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime DateOfWork { get; set; }

    public decimal Salary { get; set; }
}

public class CreateWageCommandValidator : AbstractValidator<CreateWageCommand>
{
    public CreateWageCommandValidator()
    {
        RuleFor(p => p.DepartmentId)
            .NotNull().WithMessage("{DepartmentId} is required.")
             .GreaterThan(0).WithMessage("{DepartmentId} must be greater than 0.");
        RuleFor(p => p.JobId)
            .NotNull().WithMessage("{JobId} is required.")
            .GreaterThan(0).WithMessage("{JobId} must be greater than 0.");
        RuleFor(p => p.EmployeeId)
            .NotNull().WithMessage("{EmployeeId} is required.")
            .GreaterThan(0).WithMessage("{EmployeeId} must be greater than 0.");
        RuleFor(p => p.DateOfWork)
            .NotEmpty()
            .Must(date => date != default(DateTime)).WithMessage("Date of work is required");
        RuleFor(p => p.Salary)
            .NotNull().WithMessage("{Salary} is required.")
            .GreaterThan(0).WithMessage("{Salary} must be greater than 0.");
    }
}

public class CreateWageCommandHandler(
    IApplicationDbContext dbContext,
    ILogger<CreateWageCommandHandler> logger)
    : ICommandHandler<CreateWageCommand, Wage>
{
    public async Task<Wage> Handle(CreateWageCommand request, CancellationToken cancellationToken)
    {
        var wage = Wage.Create(
            request.DepartmentId,
            request.JobId,
            request.EmployeeId,
            request.DateOfWork,
            request.Salary);
        dbContext.Wages.Add(wage);
        await dbContext.SaveChangesAsync(cancellationToken);

        logger.LogInformation("{message} {departmentId} {jobId} {employeeId}", $"Wage with DepartmentId - {wage.DepartmentId} and JobId - {wage.JobId} and EmployeeId - {wage.EmployeeId} is successfully created.", wage.DepartmentId, wage.JobId, wage.EmployeeId);

        return wage;
    }
}
