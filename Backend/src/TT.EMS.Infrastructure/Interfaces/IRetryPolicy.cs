namespace TT.EMS.Infrastructure.Interfaces;

/// <summary>
/// Represents a retry policy that defines how to execute a task with retry logic.
/// </summary>
public interface IRetryPolicy
{
    /// <summary>
    /// Executes the specified asynchronous action with retry logic.
    /// </summary>
    /// <param name="action">The asynchronous action to execute.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task ExecuteAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken = default);
}