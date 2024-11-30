using BuildingBlocks.CQRS;
using DataAccounting.Application.Contracts;
using DataAccounting.Application.Exceptions;
using DataAccounting.Domain.Models;
using Microsoft.Extensions.Logging;

namespace DataAccounting.Application.Features.Employees.Commands;

public class DeleteEmployeeCommand : ICommand<Employee>
{
    public int Id { get; set; }

    public DeleteEmployeeCommand(int id)
    {
        Id = id;
    }
}

public class DeleteEmployeeCommandHandler(
    IApplicationDbContext dbContext,
    ILogger<DeleteEmployeeCommandHandler> logger)
    : ICommandHandler<DeleteEmployeeCommand, Employee>
{
    public async Task<Employee> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
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

        return employee;
    }
}
