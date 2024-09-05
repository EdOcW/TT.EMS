using TT.EMS.Application.Abstractions.Messaging;
using TT.EMS.Application.Employee.Models;
using TT.EMS.Domain.Shared;

namespace TT.EMS.Application.Employee.Queries.GetAll;

public sealed record GetAllEmployeesQuery : IQuery<Result<IReadOnlyCollection<EmployeeDto>>>;