using Personas.Domain.Core.Messaging;
using Personas.Domain.Interfaces;

namespace Personas.Domain.Commands.Direccion.Handlers
{
    public partial class DireccionCommandHandler : CommandHandler
    {
        private readonly IDireccionRepository _direccionRepository;

        public DireccionCommandHandler(IDireccionRepository accionRepository) {
            _direccionRepository = accionRepository ?? throw new ArgumentNullException(nameof(accionRepository));
        }
    }
}
