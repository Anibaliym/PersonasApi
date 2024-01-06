using Personas.Domain.Core.Messaging;

namespace Personas.Domain.Commands.Contacto
{
    public abstract class ContactoCommand : Command
    {
        public Guid Id { get; set; }
        public Guid IdPersona { get; set; }
        public string Celular { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string TipoContacto { get; set; } = string.Empty;
    }
}
