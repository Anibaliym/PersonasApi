using Personas.Domain.Core.Models;

namespace Personas.Application.EventSourcedNormalizers.Contacto
{
    public class ContactoHistoryData : HistoryData
    {
        public string Id { get; set; } = string.Empty;
        public string IdPersona { get; set; } = string.Empty;
        public string Celular { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string TipoContacto { get; set; } = string.Empty;
    }
}
