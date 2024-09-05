using Microsoft.EntityFrameworkCore;
using TT.EMS.Domain.Employee;
using TT.EMS.Infrastructure.Interfaces;

namespace TT.EMS.Infrastructure.Persistence;

internal sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> Options, IRetryPolicy RetryPolicy)
    : DbContext(Options)
{
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

    public async Task MigrateDatabaseAsync(CancellationToken cancellationToken) =>
        await RetryPolicy.ExecuteAsync(Database.MigrateAsync, cancellationToken);
}