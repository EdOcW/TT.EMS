namespace TT.EMS.Infrastructure.Interfaces;

/// <summary>
/// Represents an interface for initializing the database.
/// </summary>
public interface IDatabaseInitializer
{
    /// <summary>
    /// Initializes the database asynchronously.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task InitializeDatabaseAsync(CancellationToken cancellationToken = default);
}