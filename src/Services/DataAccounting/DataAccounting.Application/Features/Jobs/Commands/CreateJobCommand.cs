//using AutoMapper;
//using BuildingBlocks.CQRS;
//using DataAccounting.Application.Contracts.Persistence;
using BuildingBlocks.CQRS;
using DataAccounting.Domain.Models;
using FluentValidation;

//using FluentValidation;
using Microsoft.Extensions.Logging;

namespace DataAccounting.Application.Features.Jobs.Commands;

public class CreateJobCommand : ICommand<Job>
{
    public string Name { get; set; } = string.Empty;
}

public class AddJobCommandValidator : AbstractValidator<CreateJobCommand>
{
    public AddJobCommandValidator()
    {
        RuleFor(p => p.Name)
          .NotEmpty().WithMessage("{Name} is required.")
          .NotNull()
          .MinimumLength(2).WithMessage("{Name} must be longer than 2 characters.")
          .MaximumLength(50).WithMessage("{Name} must not exceed 50 characters.");
    }
}

public class CreateJobCommandHandler : ICommandHandler<CreateJobCommand, Job>
{
    //private readonly IJobRepository _departmentRepository;
    //private readonly IMapper _mapper;
    private readonly ILogger<CreateJobCommandHandler> _logger;

    public CreateJobCommandHandler(
        //IJobRepository departmentRepository,
        //IMapper mapper,
        ILogger<CreateJobCommandHandler> logger)
    {
        //_departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
        //_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Job> Handle(CreateJobCommand request, CancellationToken cancellationToken)
    {
        //var departmenEntity = _mapper.Map<Job>(request);
        //var departmentAdded = await _departmentRepository.AddAsync(departmenEntity);

        //_logger.LogInformation("{message} {departmentId}", $"Job {departmentAdded.Id} is successfully created.", departmentAdded.Id);

        var departmentAdded = new Job
        {
            Id = Random.Shared.Next(),
            Name = request.Name,
        };

        return departmentAdded; //.Id;
    }
}
