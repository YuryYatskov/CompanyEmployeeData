using BuildingBlocks.CQRS;
//using DataAccounting.Application.Contracts.Persistence;
using DataAccounting.Domain.Models;
using Microsoft.Extensions.Logging;

namespace DataAccounting.Application.Features.Jobs.Commands;

public class DeleteJobCommand : ICommand<int>
{
    public int Id { get; set; }
}

public class DeleteJobCommandHandler : ICommandHandler<DeleteJobCommand, int>
{
    //private readonly IJobRepository _departmentRepository;
    private readonly ILogger<DeleteJobCommandHandler> _logger;

    public DeleteJobCommandHandler(
        //IJobRepository departmentRepository,
        ILogger<DeleteJobCommandHandler> logger)
    {
        //_departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<int> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
    {
        //var departmenToDelete = await _departmentRepository.GetByIdAsync(request.Id);
        //if (departmenToDelete is null)
        //{
        //    var message = $"Job with identifier {request.Id} not exist on database.";
        //    _logger.LogWarning("{message} {departmenId}", message, request.Id);
        //    throw new KeyNotFoundException(message);
        //}

        //await _departmentRepository.DeleteAsync(departmenToDelete);

        //_logger.LogInformation("{message} {departmenId}", $"Job {departmenToDelete.Id} is successfully deleted.", departmenToDelete.Id);
        //return departmenToDelete.Id;

        return Random.Shared.Next();
    }
}
