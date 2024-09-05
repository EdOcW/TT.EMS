using TT.EMS.Application.Abstractions.Messaging;
using TT.EMS.Domain.Shared;

namespace TT.EMS.Application.Employee.Commands.DeleteRange;

public sealed record DeleteRangeEmployeesCommand(
    IReadOnlyCollection<Guid> Employees
) : ICommand<Result>;