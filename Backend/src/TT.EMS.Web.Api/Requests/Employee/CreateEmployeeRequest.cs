using TT.EMS.Domain.Enums;

namespace TT.EMS.Web.Api.Requests.Employee;

public sealed record CreateEmployeeRequest(
    string FirstName,
    string LastName,
    int? Age,
    Sex? Sex
);