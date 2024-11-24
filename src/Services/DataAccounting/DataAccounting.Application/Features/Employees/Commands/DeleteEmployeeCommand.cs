using BuildingBlocks.CQRS;
using DataAccounting.Application.Contracts;
using DataAccounting.Application.Exceptions;
using Microsoft.Extensions.Logging;

namespace DataAccounting.Application.Features.Employees.Commands;

public class DeleteEmployeeCommand : ICommand<int>
{
    public int Id { get; set; }
}

public class DeleteEmployeeCommandHandler(
    IApplicationDbContext dbContext,
    ILogger<DeleteEmployeeCommandHandler> logger)
    : ICommandHandler<DeleteEmployeeCommand, int>
{
    public async Task<int> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await dbContext.Employees
            .FindAsync([request.Id], cancellationToken: cancellationToken);

        if (employee is null)
        {
            throw new EmployeeNotFoundException(request.Id);
        }

        dbContext.Employees.Remove(employee);
        await dbContext.SaveChangesAsync(cancellationToken);

        logger.LogInformation("{message} {employeeId}", $"Employee {employee.Id} is successfully deleted.", employee.Id);

        return employee.Id;
    }
}
