//using AutoMapper;
//using BuildingBlocks.CQRS;
//using DataAccounting.Application.Contracts.Persistence;
using BuildingBlocks.CQRS;
using DataAccounting.Domain.Models;
using FluentValidation;

//using FluentValidation;
using Microsoft.Extensions.Logging;

namespace DataAccounting.Application.Features.Employees.Commands;

public class CreateEmployeeCommand : ICommand<Employee>
{
    public string Name { get; set; } = string.Empty;
}

public class AddEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public AddEmployeeCommandValidator()
    {
        RuleFor(p => p.Name)
          .NotEmpty().WithMessage("{Name} is required.")
          .NotNull()
          .MinimumLength(2).WithMessage("{Name} must be longer than 2 characters.")
          .MaximumLength(50).WithMessage("{Name} must not exceed 50 characters.");
    }
}

public class CreateEmployeeCommandHandler : ICommandHandler<CreateEmployeeCommand, Employee>
{
    //private readonly IEmployeeRepository _departmentRepository;
    //private readonly IMapper _mapper;
    private readonly ILogger<CreateEmployeeCommandHandler> _logger;

    public CreateEmployeeCommandHandler(
        //IEmployeeRepository departmentRepository,
        //IMapper mapper,
        ILogger<CreateEmployeeCommandHandler> logger)
    {
        //_departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
        //_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        //var departmenEntity = _mapper.Map<Employee>(request);
        //var departmentAdded = await _departmentRepository.AddAsync(departmenEntity);

        //_logger.LogInformation("{message} {departmentId}", $"Employee {departmentAdded.Id} is successfully created.", departmentAdded.Id);

        var departmentAdded = new Employee
        {
            Id = Random.Shared.Next(),
            Name = request.Name,
        };

        return departmentAdded; //.Id;
    }
}
