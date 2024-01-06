using System.ComponentModel;

namespace Personas.Application.ViewModels.Direccion
{
    public class DireccionModificarViewModel
    {
        [DisplayName("Id")]
        public Guid Id { get; set; }

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
