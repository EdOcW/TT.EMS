using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TT.EMS.Domain.Employee;
using TT.EMS.Infrastructure.Persistence.SeedData;

namespace TT.EMS.Infrastructure.Persistence.Configuration;

internal sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .IsRequired()
            .ValueGeneratedNever();

        builder.Property(e => e.FirstName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.LastName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.Age)
            .IsRequired();

        builder.Property(u => u.Sex)
           .IsRequired()
           .HasConversion<string>()
           .HasMaxLength(20);

        SeedEmployeesHelper.SeedEmployeesData(builder);
    }
}