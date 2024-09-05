using Mapster;
using MediatR;
using TT.EMS.Application.Abstractions.Messaging;
using TT.EMS.Application.Employee.Models;
using TT.EMS.Application.Interfaces;
using TT.EMS.Domain.Shared;

namespace TT.EMS.Application.Employee.Queries.GetAll;

internal sealed class GetAllEmployeesQueryHandler(IUnitOfWork UnitOfWork)
    : IQueryHandler<GetAllEmployeesQuery, Result<IReadOnlyCollection<EmployeeDto>>>
{
    async Task<Result<IReadOnlyCollection<EmployeeDto>>> IRequestHandler<GetAllEmployeesQuery, Result<IReadOnlyCollection<EmployeeDto>>>.Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await UnitOfWork.EmployeeRepository.GetListAsync(cancellationToken);

        IReadOnlyCollection<EmployeeDto> employeesDtos = employees.Select(e => e.Adapt<EmployeeDto>()).ToList();

        return Result.Success(employeesDtos);
    }
}