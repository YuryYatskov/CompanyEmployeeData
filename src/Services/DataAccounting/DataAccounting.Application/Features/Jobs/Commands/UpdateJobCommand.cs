using BuildingBlocks.CQRS;
using DataAccounting.Application.Contracts;
using DataAccounting.Application.Exceptions;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace DataAccounting.Application.Features.Jobs.Commands;

public class UpdateJobCommand : ICommand<int>
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
          .MaximumLength(100).WithMessage("{Name} must not exceed 100 characters.");
    }
}

public class UpdateJobCommandHandler(
    IApplicationDbContext dbContext,
    ILogger<UpdateJobCommandHandler> logger)
    : ICommandHandler<UpdateJobCommand, int>
{
    public async Task<int> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
    {
        var job = await dbContext.Jobs
            .FindAsync([request.Id], cancellationToken: cancellationToken);

        if (job is null)
        {
            throw new DepartmentNotFoundException(request.Id);
        }

        job.Update(request.Name);

        dbContext.Jobs.Update(job);
        await dbContext.SaveChangesAsync(cancellationToken);

        logger.LogInformation("{message} {jobId}", $"Job {job.Id} is successfully updated.", job.Id);

        return job.Id;
    }
}
