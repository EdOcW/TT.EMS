using TT.EMS.Domain.Enums;

namespace TT.EMS.Web.Api.Responces.Employee;

public sealed record EmployeeResponce(
    Guid Id,
    string FirstName,
    string LastName,
    int Age,
    Sex Sex
);