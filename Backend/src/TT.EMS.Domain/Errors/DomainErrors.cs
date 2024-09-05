using TT.EMS.Domain.Shared;

namespace TT.EMS.Domain.Errors;

public static class DomainErrors
{
    public static class Employee
    {
        public static readonly Error NotFound = new("Employee.NotFound", "Employee not found.");
        public static readonly Error AlreadyExists = new("Employee.AlreadyExists", "Employee already exists.");
        public static readonly Error FirstNameRequired = new("Employee.FirstNameRequired", "Employee first name is required.");
        public static readonly Error LastNameRequired = new("Employee.LastNameRequired", "Employee last name is required.");
        public static readonly Error InvalidAge = new("Employee.InvalidAge", "Employee age must be between 18 and 100.");
        public static readonly Error InvalidSex = new("Employee.InvalidSex", "Employee sex is required.");
    }
}