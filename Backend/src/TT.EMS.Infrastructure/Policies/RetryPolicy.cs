using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;

namespace TT.EMS.Infrastructure.Policies;

/// <inheritdoc>
internal sealed class RetryPolicy : Interfaces.IRetryPolicy
{
    private const int MaxRetryAttempts = 3;
    private readonly AsyncRetryPolicy _retryPolicy;
    private readonly ILogger<RetryPolicy> _logger;

    public RetryPolicy(ILogger<RetryPolicy> logger)
    {
        _logger = logger;

        _retryPolicy = Policy.Handle<Exception>()
            .WaitAndRetryAsync(
                MaxRetryAttempts,
                retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                (exception, timeSpan, retryCount, context) =>
                {
                    _logger.LogWarning(exception, "Retry {RetryCount} after {TimeSpan}", retryCount, timeSpan);
                });
    }

    /// <inheritdoc>
    public Task ExecuteAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken) =>
        _retryPolicy.ExecuteAsync(action, cancellationToken);
}
