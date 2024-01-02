using MediatR;

namespace Personas.Domain.Core.Messaging
{
    public abstract class Command : Message, IRequest<CommandResponse>
    {
        public CommandResponse CommandResponse { get; set; }

        protected Command()
        {
            CommandResponse = new CommandResponse();
        }

        public virtual bool IsValid()
        {
            return CommandResponse.ValidationResult.IsValid;
        }
    }
}
