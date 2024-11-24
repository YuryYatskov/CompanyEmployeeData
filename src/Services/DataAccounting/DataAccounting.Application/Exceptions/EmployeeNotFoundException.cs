using BuildingBlocks.Exceptions;

namespace DataAccounting.Application.Exceptions;

public class EmployeeNotFoundException : NotFoundException
{
    public EmployeeNotFoundException(int id) : base("Employee", id)
    {
    }
}