using BuildingBlocks.CQRS;
using DataAccounting.Application.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccounting.Application.Features.Wages.Queries;

public record GetWageQueryById(
    int DepartmentId,
    int JobId,
    int EmployeeId,
    DateTime DateOfWork) 
    : IQuery<GetWageByIdResponse>;

public record GetWageByIdResponse(WagesResponse? Wage);

public class GetWageQueryByIdHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetWageQueryById, GetWageByIdResponse>
{
    public async Task<GetWageByIdResponse> Handle(GetWageQueryById request, CancellationToken cancellationToken)
    {
        var wage = await dbContext.Wages.Where(x 
            => x.DepartmentId == request.DepartmentId
            && x.JobId == request.JobId
            && x.EmployeeId == request.EmployeeId
            && x.DateOfWork == request.DateOfWork)
        .Join(dbContext.Departments,
            x => x.DepartmentId,
            y => y.Id,
            (x, y) => new
            {
                x.DepartmentId,
                DepartmentName = y.Name,
                x.JobId,
                x.EmployeeId,
                x.DateOfWork,
                x.Salary
            })
        .Join(dbContext.Jobs,
            x => x.JobId,
            y => y.Id,
            (x, y) => new
            {
                x.DepartmentId,
                x.DepartmentName,
                x.JobId,
                JobName = y.Name,
                x.EmployeeId,
                x.DateOfWork,
                x.Salary
            })
        .Join(dbContext.Employees,
            x => x.EmployeeId,
            y => y.Id,
            (x, y) => new
            {
                x.DepartmentId,
                x.DepartmentName,
                x.JobId,
                x.JobName,
                x.EmployeeId,
                EmployeeName = y.Name,
                y.Phone,
                y.DateOfBirth,
                y.Address,
                x.DateOfWork,
                x.Salary
            })
        .Select(x => new WagesResponse(x.DepartmentId, x.DepartmentName, x.JobId, x.JobName, x.EmployeeId, x.EmployeeName, x.Phone, x.DateOfBirth, x.Address, x.DateOfWork, x.Salary))
        .FirstOrDefaultAsync(cancellationToken);

        return new GetWageByIdResponse(wage);
    }
}
