using Personas.Domain.Core.Messaging;
using Personas.Domain.Interfaces;

namespace Personas.Domain.Commands.Persona.Handlers
{
    public partial class PersonaCommandHandler : CommandHandler
    {
        private readonly IPersonaRepository _personaRepository;

        public PersonaCommandHandler(IPersonaRepository accionRepository)
        {
            _personaRepository = accionRepository ?? throw new ArgumentNullException(nameof(accionRepository));
        }
    }
}
