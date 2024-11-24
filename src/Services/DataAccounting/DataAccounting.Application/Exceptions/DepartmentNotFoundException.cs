using BuildingBlocks.Exceptions;

namespace DataAccounting.Application.Exceptions;

public class DepartmentNotFoundException : NotFoundException
{
    public DepartmentNotFoundException(int id) : base("Department", id)
    {
    }
}
