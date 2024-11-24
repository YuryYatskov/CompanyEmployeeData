//using AutoMapper;
using BuildingBlocks.CQRS;
using DataAccounting.Domain.Models;

//using DataAccounting.Application.Contracts.Persistence;
//using DataAccounting.Domain.Models;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace DataAccounting.Application.Features.Jobs.Commands;

public class UpdateJobCommand : ICommand<Job>
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
}

public class UpdateJobCommandValidator : AbstractValidator<UpdateJobCommand>
{
    public UpdateJobCommandValidator()
    {
        RuleFor(p => p.Name)
          .NotEmpty().WithMessage("{Name} is required.")
          .NotNull()
          .MinimumLength(2).WithMessage("{Name} must be longer than 2 characters.")
          .MaximumLength(50).WithMessage("{Name} must not exceed 50 characters.");
    }
}

public class UpdateJobCommandHandler : ICommandHandler<UpdateJobCommand, Job>
{
    //private readonly IJobRepository _departmentRepository;
    //private readonly IMapper _mapper;
    private readonly ILogger<UpdateJobCommandHandler> _logger;

    public UpdateJobCommandHandler(
        //IJobRepository departmentRepository,
        //IMapper mapper,
        ILogger<UpdateJobCommandHandler> logger)
    {
    //    _departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
    //    _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Job> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
    {
        //var departmenToUpdate = await _departmentRepository.GetByIdAsync(request.Id);
        //if (departmenToUpdate is null)
        //{
        //    var message = $"Job with identifier {request.Id} not exist on database.";
        //    _logger.LogWarning("{message} {departmentId}", message, request.Id);
        //    throw new KeyNotFoundException(message);
        //}

        //_mapper.Map(request, departmenToUpdate, typeof(UpdateJobCommand), typeof(Job));

        //await _departmentRepository.UpdateAsync(departmenToUpdate);

        //_logger.LogInformation("{message} {departmentId}", $"Job {departmenToUpdate.Id} is successfully updated.", departmenToUpdate.Id);

        //return departmenToUpdate.Id;

        var departmenToUpdate = new Job
        {
            Id = Random.Shared.Next(),
            Name = request.Name,
        };

        return departmenToUpdate; //.Id;
    }
}
