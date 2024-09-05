using TT.EMS.Application.Abstractions.Messaging;
using TT.EMS.Application.Employee.Models;
using TT.EMS.Domain.Shared;

namespace TT.EMS.Application.Employee.Queries.GetById;

public sealed record GetEmployeeByIdQuery(
    Guid Id
) : IQuery<Result<EmployeeDto>>;