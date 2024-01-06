using System.ComponentModel;

namespace Personas.Application.ViewModels.ServiciosDeDominio
{
    public class Obtener_PersonaDireccionContactoViewModel
    {
        [DisplayName("Información de la persona")]
        public Domain.Entities.Persona Persona { get; set; }

        [DisplayName("Información de la direccion")]
        public Domain.Entities.Direccion Direccion { get; set; }

        [DisplayName("Información de la Contacto")]
        public IList<Domain.Entities.Contacto> Contacto { get; set; }
    }
}
