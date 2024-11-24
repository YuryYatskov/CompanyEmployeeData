using BuildingBlocks.CQRS;
//using DataAccounting.Application.Contracts.Persistence;
using DataAccounting.Domain.Models;
using Microsoft.Extensions.Logging;

namespace DataAccounting.Application.Features.Departments.Commands;

public class DeleteDepartmentCommand : ICommand<int>
{
    public int Id { get; set; }
}

public class DeleteDepartmentCommandHandler : ICommandHandler<DeleteDepartmentCommand, int>
{
    //private readonly IDepartmentRepository _departmentRepository;
    private readonly ILogger<DeleteDepartmentCommandHandler> _logger;

    public DeleteDepartmentCommandHandler(
        //IDepartmentRepository departmentRepository,
        ILogger<DeleteDepartmentCommandHandler> logger)
    {
        //_departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<int> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
    {
        //var departmenToDelete = await _departmentRepository.GetByIdAsync(request.Id);
        //if (departmenToDelete is null)
        //{
        //    var message = $"Department with identifier {request.Id} not exist on database.";
        //    _logger.LogWarning("{message} {departmenId}", message, request.Id);
        //    throw new KeyNotFoundException(message);
        //}

        //await _departmentRepository.DeleteAsync(departmenToDelete);

        //_logger.LogInformation("{message} {departmenId}", $"Department {departmenToDelete.Id} is successfully deleted.", departmenToDelete.Id);
        //return departmenToDelete.Id;

        return Random.Shared.Next();
    }
}
