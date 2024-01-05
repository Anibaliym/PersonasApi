using Personas.Domain.Core.Messaging;
using Personas.Domain.Interfaces;

namespace Personas.Domain.Commands.Contacto.Handlers
{
    public partial class ContactoCommandHandler : CommandHandler
    {
        private readonly IContactoRepository _contactoRepository;

        public ContactoCommandHandler(IContactoRepository accionRepository)
        {
            _contactoRepository = accionRepository ?? throw new ArgumentNullException(nameof(accionRepository));
        }

    }
}
