using Mapster;
using MediatR;
using TT.EMS.Application.Abstractions.Messaging;
using TT.EMS.Application.Employee.Models;
using TT.EMS.Application.Interfaces;
using TT.EMS.Domain.Errors;
using TT.EMS.Domain.Shared;

namespace TT.EMS.Application.Employee.Queries.GetById;

internal sealed record GetEmployeeByIdQueryHandler(IUnitOfWork UnitOfWork)
    : IQueryHandler<GetEmployeeByIdQuery, Result<EmployeeDto>>
{
    async Task<Result<EmployeeDto>> IRequestHandler<GetEmployeeByIdQuery, Result<EmployeeDto>>.Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var employee = await UnitOfWork.EmployeeRepository.GetByIdAsync(request.Id, cancellationToken);

        return employee is not null
            ? Result.Success(employee.Adapt<EmployeeDto>())
            : Result.Failure<EmployeeDto>(DomainErrors.Employee.NotFound);
    }
}