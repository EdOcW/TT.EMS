using TT.EMS.Domain.Enums;

namespace TT.EMS.Application.Employee.Models;

public sealed record EmployeeDto(
    Guid Id,
    string FirstName,
    string LastName,
    int Age,
    Sex Sex
);