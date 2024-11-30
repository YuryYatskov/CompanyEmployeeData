using BuildingBlocks.CQRS;
using DataAccounting.Application.Contracts;
using DataAccounting.Domain.Models;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace DataAccounting.Application.Features.Jobs.Commands;

public class CreateJobCommand : ICommand<Job>
{
    public string Name { get; set; } = string.Empty;
}

public class CreateJobCommandValidator : AbstractValidator<CreateJobCommand>
{
    public CreateJobCommandValidator()
    {
        RuleFor(p => p.Name)
          .NotEmpty().WithMessage("{Name} is required.")
          .NotNull()
          .MinimumLength(2).WithMessage("{Name} must be longer than 2 characters.")
          .MaximumLength(100).WithMessage("{Name} must not exceed 100 characters.");
    }
}

public class CreateJobCommandHandler(
    IApplicationDbContext dbContext,
    ILogger<CreateJobCommandHandler> logger)
    : ICommandHandler<CreateJobCommand, Job>
{
    public async Task<Job> Handle(CreateJobCommand request, CancellationToken cancellationToken)
    {
        var job = Job.Create(request.Name);
        dbContext.Jobs.Add(job);
        await dbContext.SaveChangesAsync(cancellationToken);

        logger.LogInformation("{message} {jobId}", $"Job {job.Id} is successfully created.", job.Id);

        return job;
    }
}
