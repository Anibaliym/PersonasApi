using Personas.Domain.Core.Messaging;

namespace Personas.Domain.Events.Persona.Events
{
    public class PersonaModificarEvent : Event
    {
        public PersonaModificarEvent(Guid id, string rut, string nombre, string apellidoPaterno, string apellidoMaterno, DateTime fechaNacimiento, string genero)
        {
            Id = id;
            Rut = rut;
            Nombre = nombre;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            FechaNacimiento = fechaNacimiento;
            Genero = genero;

            AggregateId = id;
        }

        public Guid Id { get; set; }
        public string Rut { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string ApellidoPaterno { get; set; } = string.Empty;
        public string ApellidoMaterno { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; } = string.Empty;
    }
}
