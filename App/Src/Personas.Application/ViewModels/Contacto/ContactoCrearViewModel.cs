using System.ComponentModel;

namespace Personas.Application.ViewModels.Contacto
{
    public class ContactoCrearViewModel
    {
        [DisplayName("Id Persona")]
        public Guid IdPersona { get; set; }

        [DisplayName("Celular")]
        public string Celular { get; set; } = string.Empty;

        [DisplayName("Correo Electronico Personal")]
        public string Email { get; set; } = string.Empty;

        [DisplayName("Tipo De Contacto")]
        public string TipoContacto { get; set; } = string.Empty;
    }

}
