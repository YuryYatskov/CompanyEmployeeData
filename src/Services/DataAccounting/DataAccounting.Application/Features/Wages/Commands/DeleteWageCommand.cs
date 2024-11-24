using BuildingBlocks.CQRS;
//using DataAccounting.Application.Contracts.Persistence;
using DataAccounting.Domain.Models;
using Microsoft.Extensions.Logging;

namespace DataAccounting.Application.Features.Wages.Commands;

public class DeleteWageCommand : ICommand<int>
{
    public int Id { get; set; }
}

public class DeleteWageCommandHandler : ICommandHandler<DeleteWageCommand, int>
{
    //private readonly IWageRepository _departmentRepository;
    private readonly ILogger<DeleteWageCommandHandler> _logger;

    public DeleteWageCommandHandler(
        //IWageRepository departmentRepository,
        ILogger<DeleteWageCommandHandler> logger)
    {
        //_departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<int> Handle(DeleteWageCommand request, CancellationToken cancellationToken)
    {
        //var departmenToDelete = await _departmentRepository.GetByIdAsync(request.Id);
        //if (departmenToDelete is null)
        //{
        //    var message = $"Wage with identifier {request.Id} not exist on database.";
        //    _logger.LogWarning("{message} {departmenId}", message, request.Id);
        //    throw new KeyNotFoundException(message);
        //}

        //await _departmentRepository.DeleteAsync(departmenToDelete);

        //_logger.LogInformation("{message} {departmenId}", $"Wage {departmenToDelete.Id} is successfully deleted.", departmenToDelete.Id);
        //return departmenToDelete.Id;

        return Random.Shared.Next();
    }
}
