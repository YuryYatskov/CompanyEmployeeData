﻿using BuildingBlocks.CQRS;
using DataAccounting.Application.Contracts;
using DataAccounting.Application.Exceptions;
using Microsoft.Extensions.Logging;

namespace DataAccounting.Application.Features.Jobs.Commands;

public class DeleteJobCommand : ICommand<int>
{
    public int Id { get; set; }
}

public class DeleteJobCommandHandler(
    IApplicationDbContext dbContext,
    ILogger<DeleteJobCommandHandler> logger)
    : ICommandHandler<DeleteJobCommand, int>
{
    public async Task<int> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
    {
        var job = await dbContext.Jobs
            .FindAsync([request.Id], cancellationToken: cancellationToken);

        if (job is null)
        {
            throw new JobNotFoundException(request.Id);
        }

        dbContext.Jobs.Remove(job);
        await dbContext.SaveChangesAsync(cancellationToken);

        logger.LogInformation("{message} {jobId}", $"Job {job.Id} is successfully deleted.", job.Id);

        return job.Id;
    }
}
