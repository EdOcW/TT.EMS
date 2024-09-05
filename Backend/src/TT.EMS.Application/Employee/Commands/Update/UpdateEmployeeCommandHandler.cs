using TT.EMS.Application.Abstractions.Messaging;
using TT.EMS.Application.Interfaces;
using TT.EMS.Domain.Errors;
using TT.EMS.Domain.Shared;

namespace TT.EMS.Application.Employee.Commands.Update;

internal sealed class UpdateEmployeeCommandHandler(IUnitOfWork UnitOfWork)
    : ICommandHandler<UpdateEmployeeCommand, Result>
{
    public async Task<Result> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var currentEmployee = await UnitOfWork.EmployeeRepository.GetByIdAsync(request.Id, cancellationToken);

        if (currentEmployee is null)
        {
            return Result.Failure(DomainErrors.Employee.NotFound);
        }

        var updateResult = Domain.Employee.Employee.Update(currentEmployee, request.FirstName, request.LastName, request.Age, request.Sex);

        if (updateResult.IsFailure)
        {
            return updateResult;
        }

        UnitOfWork.EmployeeRepository.Update(currentEmployee);

        await UnitOfWork.SaveChangesAsync(cancellationToken);

        return updateResult;
    }
}