using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TT.EMS.Domain.Employee;
using TT.EMS.Domain.Enums;

namespace TT.EMS.Infrastructure.Persistence.SeedData;

internal static class SeedEmployeesHelper
{
    private static readonly Employee[] _employees =
    [
        Employee.Create("John", "Doe", 25, Sex.Male).Value,
        Employee.Create("Jane", "Doe", 27, Sex.Male).Value,
        Employee.Create("Alice", "Doe", 53, Sex.Female).Value,
        Employee.Create("Bob", "Doe", 59, Sex.Male).Value,
        Employee.Create("Charlie", "Dupa", 20, Sex.Other).Value,
    ];

    public static void SeedEmployeesData(EntityTypeBuilder<Employee> builder)
    {
        builder.HasData(_employees);
    }
}