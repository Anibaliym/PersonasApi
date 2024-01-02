using Personas.Domain.Core.Messaging;

namespace Personas.Domain.Commands.Direccion
{
    public abstract class DireccionCommand : Command
    {
        public Guid Id { get; set; }
        public Guid IdPersona { get; set; }
        public string Calle { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string NumeroCasaDepartamento { get; set; } = string.Empty;
        public string Comuna { get; set; } = string.Empty;
    }
}
