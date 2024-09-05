using TT.EMS.Application.Abstractions.Messaging;
using TT.EMS.Application.Interfaces;
using TT.EMS.Domain.Errors;
using TT.EMS.Domain.Shared;

namespace TT.EMS.Application.Employee.Commands.Create;

internal sealed class CreateEmployeeCommandHandler(IUnitOfWork UnitOfWork)
    : ICommandHandler<CreateEmployeeCommand, Result>
{
    public async Task<Result> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = Domain.Employee.Employee.Create(request.FirstName, request.LastName, request.Age, request.Sex);

        if (employee.IsFailure)
        {
            return Result.Failure(employee.Error);
        }

        var employeeExists =  await UnitOfWork.EmployeeRepository.GetByFilterAsync(e => 
            e.FirstName == employee.Value.FirstName 
            && e.LastName == employee.Value.LastName 
            && e.Age == employee.Value.Age 
            && e.Sex == employee.Value.Sex,
            cancellationToken);
        if (employeeExists.Count != 0)
        {
            return Result.Failure(DomainErrors.Employee.AlreadyExists);
        }

        UnitOfWork.EmployeeRepository.Insert(employee.Value);

        await UnitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}