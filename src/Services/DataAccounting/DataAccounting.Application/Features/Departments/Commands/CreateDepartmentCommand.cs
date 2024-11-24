//using AutoMapper;
//using BuildingBlocks.CQRS;
//using DataAccounting.Application.Contracts.Persistence;
using BuildingBlocks.CQRS;
using DataAccounting.Domain.Models;
using FluentValidation;

//using FluentValidation;
using Microsoft.Extensions.Logging;

namespace DataAccounting.Application.Features.Departments.Commands;

public class CreateDepartmentCommand : ICommand<Department>
{
    public string Name { get; set; } = string.Empty;
}

public class AddDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
{
    public AddDepartmentCommandValidator()
    {
        RuleFor(p => p.Name)
          .NotEmpty().WithMessage("{Name} is required.")
          .NotNull()
          .MinimumLength(2).WithMessage("{Name} must be longer than 2 characters.")
          .MaximumLength(50).WithMessage("{Name} must not exceed 50 characters.");
    }
}

public class CreateDepartmentCommandHandler : ICommandHandler<CreateDepartmentCommand, Department>
{
    //private readonly IDepartmentRepository _departmentRepository;
    //private readonly IMapper _mapper;
    private readonly ILogger<CreateDepartmentCommandHandler> _logger;

    public CreateDepartmentCommandHandler(
        //IDepartmentRepository departmentRepository,
        //IMapper mapper,
        ILogger<CreateDepartmentCommandHandler> logger)
    {
        //_departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
        //_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Department> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        //var departmenEntity = _mapper.Map<Department>(request);
        //var departmentAdded = await _departmentRepository.AddAsync(departmenEntity);

        //_logger.LogInformation("{message} {departmentId}", $"Department {departmentAdded.Id} is successfully created.", departmentAdded.Id);

        var departmentAdded = new Department
        {
            Id = Random.Shared.Next(),
            Name = request.Name,
        };

        return departmentAdded; //.Id;
    }
}
