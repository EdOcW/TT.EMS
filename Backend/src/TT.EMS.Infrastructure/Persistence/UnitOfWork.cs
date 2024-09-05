
using TT.EMS.Application.Interfaces;
using TT.EMS.Domain.Employee;

namespace TT.EMS.Infrastructure.Persistence;

/// <inheritdoc/>
internal sealed class UnitOfWork(ApplicationDbContext context, IEmployeeRepository employeeRepository)
    : IUnitOfWork, IDisposable
{
    public IEmployeeRepository EmployeeRepository { get; } = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));

    /// <inheritdoc/>
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken) =>
        context.SaveChangesAsync(cancellationToken);

    /// <inheritdoc/>
    public void Dispose() => context.Dispose();
}