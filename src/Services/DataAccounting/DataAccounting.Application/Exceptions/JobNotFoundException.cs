using BuildingBlocks.Exceptions;

namespace DataAccounting.Application.Exceptions;

public class JobNotFoundException : NotFoundException
{
    public JobNotFoundException(int id) : base("Job", id)
    {
    }
}