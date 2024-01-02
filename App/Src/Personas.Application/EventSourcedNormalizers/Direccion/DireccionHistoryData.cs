using Personas.Domain.Core.Models;

namespace Personas.Application.EventSourcedNormalizers.Direccion
{
    public class DireccionHistoryData : HistoryData
    {
        public string Id { get; set; } = string.Empty;
        public string IdPersona { get; set; } = string.Empty;
        public string Calle { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string NumeroCasaDepartamento { get; set; } = string.Empty;
        public string Comuna { get; set; } = string.Empty;
    }
}
