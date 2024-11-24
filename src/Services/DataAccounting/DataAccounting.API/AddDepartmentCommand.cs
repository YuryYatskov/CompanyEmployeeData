//using BuildingBlocks.CQRS;
//using DataAccounting.Domain.Models;

//namespace DataAccounting.API;

//public class AddDepartmentCommand : ICommand<Department>
//{
//    public string Name { get; set; } = string.Empty;
//}

////public class AddDepartmentCommandValidator : AbstractValidator<AddDepartmentCommand>
////{
////    public AddDepartmentCommandValidator()
////    {
////        RuleFor(p => p.Name)
////          .NotEmpty().WithMessage("{Name} is required.")
////          .NotNull()
////          .MinimumLength(2).WithMessage("{Name} must be longer than 2 characters.")
////          .MaximumLength(50).WithMessage("{Name} must not exceed 50 characters.");
////    }
////}

//public class AddDepartmentCommandHandler : ICommandHandler<AddDepartmentCommand, Department>
//{
//    //private readonly IDepartmentRepository _departmentRepository;
//    //private readonly IMapper _mapper;
//    private readonly ILogger<AddDepartmentCommandHandler> _logger;

//    public AddDepartmentCommandHandler(
//        //IDepartmentRepository departmentRepository,
//        //IMapper mapper,
//        ILogger<AddDepartmentCommandHandler> logger)
//    {
//        //_departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
//        //_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
//        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
//    }

//    public async Task<Department> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
//    {
//        //var departmenEntity = _mapper.Map<Department>(request);
//        //var departmentAdded = await _departmentRepository.AddAsync(departmenEntity);

//        //_logger.LogInformation("{message} {departmentId}", $"Department {departmentAdded.Id} is successfully created.", departmentAdded.Id);

//        var departmentAdded = new Department
//        {
//            Id = Random.Shared.Next(),
//            Name = request.Name,
//        };

//        return departmentAdded; //.Id;
//    }
//}

