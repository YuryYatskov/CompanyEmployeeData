using BuildingBlocks.CQRS;
//using DataAccounting.Application.Contracts.Persistence;
using DataAccounting.Domain.Models;
using Microsoft.Extensions.Logging;

namespace DataAccounting.Application.Features.Employees.Commands;

public class DeleteEmployeeCommand : ICommand<int>
{
    public int Id { get; set; }
}

public class DeleteEmployeeCommandHandler : ICommandHandler<DeleteEmployeeCommand, int>
{
    //private readonly IEmployeeRepository _departmentRepository;
    private readonly ILogger<DeleteEmployeeCommandHandler> _logger;

    public DeleteEmployeeCommandHandler(
        //IEmployeeRepository departmentRepository,
        ILogger<DeleteEmployeeCommandHandler> logger)
    {
        //_departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<int> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        //var departmenToDelete = await _departmentRepository.GetByIdAsync(request.Id);
        //if (departmenToDelete is null)
        //{
        //    var message = $"Employee with identifier {request.Id} not exist on database.";
        //    _logger.LogWarning("{message} {departmenId}", message, request.Id);
        //    throw new KeyNotFoundException(message);
        //}

        //await _departmentRepository.DeleteAsync(departmenToDelete);

        //_logger.LogInformation("{message} {departmenId}", $"Employee {departmenToDelete.Id} is successfully deleted.", departmenToDelete.Id);
        //return departmenToDelete.Id;

        return Random.Shared.Next();
    }
}
