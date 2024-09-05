using System.Linq.Expressions;

namespace TT.EMS.Domain.Employee;

/// <summary>
/// Represents a repository for managing employees.
/// </summary>
public interface IEmployeeRepository
{
    /// <summary>
    /// Inserts a new employee into the repository.
    /// </summary>
    /// <param name="employee">The employee to insert.</param>
    void Insert(Employee employee);

    /// <summary>
    /// Retrieves an employee by their ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the employee to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The retrieved employee, or null if not found.</returns>
    Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing employee in the repository.
    /// </summary>
    /// <param name="employee">The employee to update.</param>
    void Update(Employee employee);

    /// <summary>
    /// Deletes a range of employees from the repository.
    /// </summary>
    /// <param name="employees">The IDs of the employees to delete.</param>
    void DeleteRange(IEnumerable<Guid> employees);

    /// <summary>
    /// Retrieves a list of all employees asynchronously.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A read-only collection of employees.</returns>
    Task<IReadOnlyCollection<Employee>> GetListAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a filtered list of employees asynchronously.
    /// </summary>
    /// <param name="filter">The filter expression to apply.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A read-only collection of employees that match the filter.</returns>
    Task<IReadOnlyCollection<Employee>> GetByFilterAsync(Expression<Func<Employee, bool>> filter, CancellationToken cancellationToken);
}