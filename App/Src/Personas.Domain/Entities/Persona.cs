using Personas.Domain.Core.Dominio;

namespace Personas.Domain.Entities
{
    public class Persona : Entity, IAggregateRoot
    {
        public Persona(Guid id, String rut, string nombre, string apellidoPaterno, string apellidoMaterno, DateTime fechaNacimiento, string genero)
        {
            Id = id;
            Rut = rut;
            Nombre = nombre;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            FechaNacimiento = fechaNacimiento;
            Genero = genero;
        }

        protected Persona() { }

        public string Rut { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string ApellidoPaterno { get; set; } = string.Empty;
        public string ApellidoMaterno { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; } = string.Empty;
    }
}
