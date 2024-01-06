using System.ComponentModel;

namespace Personas.Application.ViewModels.Persona
{
    public class PersonaModificarViewModel
    {
        [DisplayName("Id")]
        public Guid Id { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [DisplayName("Apellido Paterno")]
        public string ApellidoPaterno { get; set; } = string.Empty;

        [DisplayName("Apellido Materno")]
        public string ApellidoMaterno { get; set; } = string.Empty;

        [DisplayName("Fecha De Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [DisplayName("Genero")]
        public string Genero { get; set; } = string.Empty;
    }
}
