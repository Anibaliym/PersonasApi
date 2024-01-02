using System.ComponentModel;

namespace Personas.Application.ViewModels.Direccion
{
    public class DireccionCrearViewModel
    {
        [DisplayName("Id Persona")]
        public Guid IdPersona { get; set; }

        [DisplayName("Calle")]
        public string Calle { get; set; } = string.Empty;

        [DisplayName("Numero")]
        public string Numero { get; set; } = string.Empty;

        [DisplayName("Numero de casa o departamento")]
        public string NumeroCasaDepartamento { get; set; } = string.Empty;

        [DisplayName("Comuna")]
        public string Comuna { get; set; } = string.Empty;
    }
}
