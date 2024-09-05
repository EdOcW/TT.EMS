using TT.EMS.Application.Abstractions.Messaging;
using TT.EMS.Domain.Enums;
using TT.EMS.Domain.Shared;

namespace TT.EMS.Application.Employee.Commands.Create;

public sealed record CreateEmployeeCommand(
    string FirstName,
    string LastName,
    int? Age,
    Sex? Sex
) : ICommand<Result>;