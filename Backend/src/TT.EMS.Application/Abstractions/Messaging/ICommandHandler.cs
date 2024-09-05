using MediatR;

namespace TT.EMS.Application.Abstractions.Messaging;

/// <summary>
/// Represents a handler for a command that returns a response.
/// </summary>
/// <typeparam name="TCommand">The type of the command.</typeparam>
/// <typeparam name="TResponse">The type of the response.</typeparam>
public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
}