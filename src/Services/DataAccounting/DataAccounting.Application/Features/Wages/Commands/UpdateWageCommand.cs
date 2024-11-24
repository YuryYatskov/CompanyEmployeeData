//using AutoMapper;
using BuildingBlocks.CQRS;
using DataAccounting.Domain.Models;

//using DataAccounting.Application.Contracts.Persistence;
//using DataAccounting.Domain.Models;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace DataAccounting.Application.Features.Wages.Commands;

public class UpdateWageCommand : ICommand<Wage>
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
}

public class UpdateWageCommandValidator : AbstractValidator<UpdateWageCommand>
{
    public UpdateWageCommandValidator()
    {
        RuleFor(p => p.Name)
          .NotEmpty().WithMessage("{Name} is required.")
          .NotNull()
          .MinimumLength(2).WithMessage("{Name} must be longer than 2 characters.")
          .MaximumLength(50).WithMessage("{Name} must not exceed 50 characters.");
    }
}

public class UpdateWageCommandHandler : ICommandHandler<UpdateWageCommand, Wage>
{
    //private readonly IWageRepository _departmentRepository;
    //private readonly IMapper _mapper;
    private readonly ILogger<UpdateWageCommandHandler> _logger;

    public UpdateWageCommandHandler(
        //IWageRepository departmentRepository,
        //IMapper mapper,
        ILogger<UpdateWageCommandHandler> logger)
    {
    //    _departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
    //    _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Wage> Handle(UpdateWageCommand request, CancellationToken cancellationToken)
    {
        //var departmenToUpdate = await _departmentRepository.GetByIdAsync(request.Id);
        //if (departmenToUpdate is null)
        //{
        //    var message = $"Wage with identifier {request.Id} not exist on database.";
        //    _logger.LogWarning("{message} {departmentId}", message, request.Id);
        //    throw new KeyNotFoundException(message);
        //}

        //_mapper.Map(request, departmenToUpdate, typeof(UpdateWageCommand), typeof(Wage));

        //await _departmentRepository.UpdateAsync(departmenToUpdate);

        //_logger.LogInformation("{message} {departmentId}", $"Wage {departmenToUpdate.Id} is successfully updated.", departmenToUpdate.Id);

        //return departmenToUpdate.Id;

        var wageToUpdate = new Wage
        {
            DepartmentId = Random.Shared.Next(),
            JobId= Random.Shared.Next(),
            EmployeeId = Random.Shared.Next(),
            Salary = Random.Shared.Next(),
            //DateOfWor,
        };

        return wageToUpdate; //.Id;
    }
}
