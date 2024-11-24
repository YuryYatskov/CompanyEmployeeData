//using AutoMapper;
//using BuildingBlocks.CQRS;
//using DataAccounting.Application.Contracts.Persistence;
using BuildingBlocks.CQRS;
using DataAccounting.Domain.Models;
using FluentValidation;

//using FluentValidation;
using Microsoft.Extensions.Logging;

namespace DataAccounting.Application.Features.Wages.Commands;

public class CreateWageCommand : ICommand<Wage>
{
    public string Name { get; set; } = string.Empty;
}

public class AddWageCommandValidator : AbstractValidator<CreateWageCommand>
{
    public AddWageCommandValidator()
    {
        RuleFor(p => p.Name)
          .NotEmpty().WithMessage("{Name} is required.")
          .NotNull()
          .MinimumLength(2).WithMessage("{Name} must be longer than 2 characters.")
          .MaximumLength(50).WithMessage("{Name} must not exceed 50 characters.");
    }
}

public class CreateWageCommandHandler : ICommandHandler<CreateWageCommand, Wage>
{
    //private readonly IWageRepository _departmentRepository;
    //private readonly IMapper _mapper;
    private readonly ILogger<CreateWageCommandHandler> _logger;

    public CreateWageCommandHandler(
        //IWageRepository departmentRepository,
        //IMapper mapper,
        ILogger<CreateWageCommandHandler> logger)
    {
        //_departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
        //_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Wage> Handle(CreateWageCommand request, CancellationToken cancellationToken)
    {
        //var departmenEntity = _mapper.Map<Wage>(request);
        //var departmentAdded = await _departmentRepository.AddAsync(departmenEntity);

        //_logger.LogInformation("{message} {departmentId}", $"Wage {departmentAdded.Id} is successfully created.", departmentAdded.Id);

        var wageAdded = new Wage
        {
            DepartmentId = Random.Shared.Next(),
            JobId = Random.Shared.Next(),
            EmployeeId = Random.Shared.Next(),
            Salary = Random.Shared.Next(),
            //DateOfWor,
        };

        return wageAdded; //.Id;
    }
}
