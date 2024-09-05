using TT.EMS.Application.Abstractions.Messaging;
using TT.EMS.Application.Interfaces;
using TT.EMS.Domain.Shared;

namespace TT.EMS.Application.Employee.Commands.DeleteRange;

internal sealed class DeleteRangeEmployeesCommandHandler(IUnitOfWork UnitOfWork)
    : ICommandHandler<DeleteRangeEmployeesCommand, Result>
{
    public async Task<Result> Handle(DeleteRangeEmployeesCommand request, CancellationToken cancellationToken)
    {
        UnitOfWork.EmployeeRepository.DeleteRange(request.Employees);

        await UnitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}