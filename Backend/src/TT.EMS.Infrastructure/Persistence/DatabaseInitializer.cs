using TT.EMS.Infrastructure.Interfaces;

namespace TT.EMS.Infrastructure.Persistence;

/// <inheritdoc>
internal sealed class DatabaseInitializer(ApplicationDbContext Context)
    : IDatabaseInitializer
{
    /// <inheritdoc>
    public Task InitializeDatabaseAsync(CancellationToken cancellationToken = default) =>
        Context.MigrateDatabaseAsync(cancellationToken);
}