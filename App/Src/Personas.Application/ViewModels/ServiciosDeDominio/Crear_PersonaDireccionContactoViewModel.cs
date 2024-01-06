using Personas.Application.ViewModels.Contacto;
using Personas.Application.ViewModels.Direccion;
using Personas.Application.ViewModels.Persona;
using System.ComponentModel;

namespace Personas.Application.ViewModels.ServiciosDeDominio
{
    public class Crear_PersonaDireccionContactoViewModel
    {
        [DisplayName("Información de la persona")]
        public PersonaCrearViewModel Persona { get; set; }

        [DisplayName("Información de la direccion")]
        public DireccionCrearViewModel Direccion { get; set; }

        [DisplayName("Información de la Contacto")]
        public ContactoCrearViewModel Contacto { get; set; }
    }
}
