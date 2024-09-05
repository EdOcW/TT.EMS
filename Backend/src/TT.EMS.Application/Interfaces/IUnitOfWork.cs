using TT.EMS.Domain.Employee;

namespace TT.EMS.Application.Interfaces;

/// <summary>
/// Represents a unit of work for managing database operations.
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Gets the repository for managing employee entities.
    /// </summary>
    IEmployeeRepository EmployeeRepository { get; }

    /// <summary>
    /// Saves the changes made in the unit of work to the underlying database asynchronously.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous save operation.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}