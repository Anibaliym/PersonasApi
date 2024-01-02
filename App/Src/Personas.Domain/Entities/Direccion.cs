using Personas.Domain.Core.Dominio;

namespace Personas.Domain.Entities
{
    public class Direccion : Entity, IAggregateRoot
    {
        public Direccion(Guid id, Guid idPersona, string calle, string numero, string numeroCasaDepartamento, string comuna)
        {
            Id = id;
            IdPersona = idPersona;
            Calle = calle;
            Numero = numero;
            NumeroCasaDepartamento = numeroCasaDepartamento;
            Comuna = comuna;
        }

        protected Direccion() { }

        public Guid Id { get; set; }
        public Guid IdPersona { get; set; }
        public string Calle { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string NumeroCasaDepartamento { get; set; } = string.Empty;
        public string Comuna { get; set; } = string.Empty;
    }
}
