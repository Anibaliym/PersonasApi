using Personas.Domain.Core.Messaging;

namespace Personas.Domain.Events.Direccion.Events
{
    public class DireccionCrearEvent : Event
    {
        public DireccionCrearEvent(Guid id, Guid idPersona, string calle, string numero, string numeroCasaDepartamento, string comuna)
        {
            Id = id;
            IdPersona = idPersona;
            Calle = calle;
            Numero = numero;
            NumeroCasaDepartamento = numeroCasaDepartamento;
            Comuna = comuna;

            AggregateId = id;
        }

        public Guid Id { get; set; }
        public Guid IdPersona { get; set; }
        public string Calle { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string NumeroCasaDepartamento { get; set; } = string.Empty;
        public string Comuna { get; set; } = string.Empty;
    }
}
