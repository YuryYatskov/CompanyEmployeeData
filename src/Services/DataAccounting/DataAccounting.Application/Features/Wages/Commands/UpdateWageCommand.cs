using BuildingBlocks.CQRS;
using DataAccounting.Application.Contracts;
using DataAccounting.Application.Exceptions;
using DataAccounting.Application.Features.Departments.Commands;
using DataAccounting.Domain.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccounting.Application.Features.Wages.Commands;

public class UpdateWageCommand : ICommand<Wage>
{
    public int DepartmentId { get; set; }

    public int JobId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime DateOfWork { get; set; }

    public decimal Salary { get; set; }
}

public class UpdateWageCommandValidator : AbstractValidator<UpdateWageCommand>
{
    public UpdateWageCommandValidator()
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

public class UpdateWageCommandHandler(
    IApplicationDbContext dbContext,
    ILogger<CreateDepartmentCommandHandler> logger)
    : ICommandHandler<UpdateWageCommand, Wage>
{
    public async Task<Wage> Handle(UpdateWageCommand request, CancellationToken cancellationToken)
    {
        var wage = await dbContext.Wages
               .FirstOrDefaultAsync(x
                    => x.DepartmentId == request.DepartmentId
                    && x.JobId == request.JobId
                    && x.EmployeeId == request.EmployeeId
                    && x.DateOfWork == request.DateOfWork,
                    cancellationToken: cancellationToken);

        if (wage is null)
        {
            throw new WageNotFoundException(
                request.DepartmentId,
                request.JobId,
                request.EmployeeId,
                request.DateOfWork);
        }

        wage.Update(request.Salary);

        dbContext.Wages.Update(wage);
        await dbContext.SaveChangesAsync(cancellationToken);

        logger.LogInformation("{message} {departmentId} {jobId} {employeeId} {dateOfWork}", $"Wage with DepartmentId - {wage.DepartmentId} and JobId - {wage.JobId} and EmployeeId - {wage.EmployeeId} and DateOfWork - {wage.DateOfWork} is successfully updated.",
            wage.DepartmentId, wage.JobId, wage.EmployeeId, wage.DateOfWork);


        return wage;
    }
}
