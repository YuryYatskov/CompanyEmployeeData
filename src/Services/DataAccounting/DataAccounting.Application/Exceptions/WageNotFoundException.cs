using BuildingBlocks.Exceptions;

namespace DataAccounting.Application.Exceptions;

public class WageNotFoundException : NotFoundException
{
    public WageNotFoundException(
        int departmentId,
        int jobId,
        int employeeId,
        DateTime dateOfWork)
        : base("Wage", $"departmentId - {departmentId} and jobId - {jobId} and employeeId - {employeeId} and dateOfWork - {dateOfWork}")
    {
    }
}
