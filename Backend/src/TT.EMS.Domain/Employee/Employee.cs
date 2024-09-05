using TT.EMS.Domain.Abstractions;
using TT.EMS.Domain.Enums;
using TT.EMS.Domain.Errors;
using TT.EMS.Domain.Shared;

namespace TT.EMS.Domain.Employee;

public sealed class Employee : Entity
{
    private const int MinAge = 18;
    private const int MaxAge = 100;

    private Employee(Guid id, string firstName, string lastName, int age, Sex sex)
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Sex = sex;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public int Age { get; private set; }
    public Sex Sex { get; private set; }

    public static Result<Employee> Create(string firstName, string lastName, int? age, Sex? sex)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            return Result.Failure<Employee>(DomainErrors.Employee.FirstNameRequired);
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            return Result.Failure<Employee>(DomainErrors.Employee.LastNameRequired);
        }

        if (!age.HasValue || age < MinAge || age > MaxAge)
        {
            return Result.Failure<Employee>(DomainErrors.Employee.InvalidAge);
        }

        if (!sex.HasValue)
        {
            return Result.Failure<Employee>(DomainErrors.Employee.InvalidSex);
        }

        return Result.Success(new Employee(Guid.NewGuid(), firstName, lastName, age.Value, sex.Value));
    }

    public static Result<Employee> Update(Employee destination, string firstName, string lastName, int? age, Sex? sex)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            return Result.Failure<Employee>(DomainErrors.Employee.FirstNameRequired);
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            return Result.Failure<Employee>(DomainErrors.Employee.LastNameRequired);
        }

        if (!age.HasValue || age < MinAge || age > MaxAge)
        {
            return Result.Failure<Employee>(DomainErrors.Employee.InvalidAge);
        }

        if (!sex.HasValue)
        {
            return Result.Failure<Employee>(DomainErrors.Employee.InvalidSex);
        }

        destination.FirstName = firstName;
        destination.LastName = lastName;
        destination.Age = age.Value;
        destination.Sex = sex.Value;

        return Result.Success(destination);
    }
}