using BuildingBlocks.CQRS;
using DataAccounting.Application.Contracts;
using DataAccounting.Application.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccounting.Application.Features.Wages.Commands;

public class DeleteWageCommand : ICommand<bool>
{
    public int DepartmentId { get; set; }

    public int JobId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime DateOfWork { get; set; }

    public DeleteWageCommand(int departmentId, int jobId, int employeeId, DateTime dateOfWork)
    { 
        DepartmentId = departmentId;
        JobId = jobId;
        EmployeeId = employeeId;
        DateOfWork = dateOfWork;
    }
}

public class DeleteWageCommandHandler(
    IApplicationDbContext dbContext,
    ILogger<DeleteWageCommandHandler> logger)
    : ICommandHandler<DeleteWageCommand, bool>
{
    public async Task<bool> Handle(DeleteWageCommand request, CancellationToken cancellationToken)
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

        dbContext.Wages.Remove(wage);
        await dbContext.SaveChangesAsync(cancellationToken);

        logger.LogInformation("{message} {departmentId} {jobId} {employeeId} {dateOfWork}", $"Wage with DepartmentId - {wage.DepartmentId} and JobId - {wage.JobId} and EmployeeId - {wage.EmployeeId} and DateOfWork - {wage.DateOfWork} is successfully deleted.",
            wage.DepartmentId, wage.JobId, wage.EmployeeId, wage.DateOfWork);

        return true;
    }
}
