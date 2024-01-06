using Personas.Domain.Core.Messaging;

namespace Personas.Domain.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T @event) where T : Event;
        Task<CommandResponse> SendCommand<T>(T command) where T : Command;
    }
}
