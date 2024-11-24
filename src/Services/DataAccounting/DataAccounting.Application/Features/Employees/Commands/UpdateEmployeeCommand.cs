//using AutoMapper;
using BuildingBlocks.CQRS;
using DataAccounting.Domain.Models;

//using DataAccounting.Application.Contracts.Persistence;
//using DataAccounting.Domain.Models;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace DataAccounting.Application.Features.Employees.Commands;

public class UpdateEmployeeCommand : ICommand<Employee>
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
}

public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator()
    {
        RuleFor(p => p.Name)
          .NotEmpty().WithMessage("{Name} is required.")
          .NotNull()
          .MinimumLength(2).WithMessage("{Name} must be longer than 2 characters.")
          .MaximumLength(50).WithMessage("{Name} must not exceed 50 characters.");
    }
}

public class UpdateEmployeeCommandHandler : ICommandHandler<UpdateEmployeeCommand, Employee>
{
    //private readonly IEmployeeRepository _departmentRepository;
    //private readonly IMapper _mapper;
    private readonly ILogger<UpdateEmployeeCommandHandler> _logger;

    public UpdateEmployeeCommandHandler(
        //IEmployeeRepository departmentRepository,
        //IMapper mapper,
        ILogger<UpdateEmployeeCommandHandler> logger)
    {
    //    _departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
    //    _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Employee> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        //var departmenToUpdate = await _departmentRepository.GetByIdAsync(request.Id);
        //if (departmenToUpdate is null)
        //{
        //    var message = $"Employee with identifier {request.Id} not exist on database.";
        //    _logger.LogWarning("{message} {departmentId}", message, request.Id);
        //    throw new KeyNotFoundException(message);
        //}

        //_mapper.Map(request, departmenToUpdate, typeof(UpdateEmployeeCommand), typeof(Employee));

        //await _departmentRepository.UpdateAsync(departmenToUpdate);

        //_logger.LogInformation("{message} {departmentId}", $"Employee {departmenToUpdate.Id} is successfully updated.", departmenToUpdate.Id);

        //return departmenToUpdate.Id;

        var departmenToUpdate = new Employee
        {
            Id = Random.Shared.Next(),
            Name = request.Name,
        };

        return departmenToUpdate; //.Id;
    }
}
