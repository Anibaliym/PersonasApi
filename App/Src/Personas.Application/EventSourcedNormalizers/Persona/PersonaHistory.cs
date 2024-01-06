using Newtonsoft.Json;
using Personas.Domain.Core.Enumerations;
using Personas.Domain.Core.Events;
using System.Web;

namespace Personas.Application.EventSourcedNormalizers.Persona
{
    public static class PersonaHistory
    {
        public static IList<PersonaHistoryData> HistoryData { get; set; }

        public static IList<PersonaHistoryData> ToJavaScriptCustomerHistory(IList<History> storedEvents)
        {
            HistoryData = new List<PersonaHistoryData>();
            ClienteHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.Timestamp);
            var list = new List<PersonaHistoryData>();
            var last = new PersonaHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new PersonaHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id ? "" : change.Id,
                    Rut = string.IsNullOrWhiteSpace(change.Rut) || change.Rut == last.Rut ? "" : change.Rut,
                    Nombre = string.IsNullOrWhiteSpace(change.Nombre) || change.Nombre == last.Nombre ? "" : change.Nombre,
                    ApellidoPaterno = string.IsNullOrWhiteSpace(change.ApellidoPaterno) || change.ApellidoPaterno == last.ApellidoPaterno ? "" : change.ApellidoPaterno,
                    ApellidoMaterno = string.IsNullOrWhiteSpace(change.ApellidoMaterno) || change.ApellidoMaterno == last.ApellidoMaterno ? "" : change.ApellidoMaterno,
                    FechaNacimiento = string.IsNullOrWhiteSpace(change.FechaNacimiento) || change.FechaNacimiento == last.FechaNacimiento ? "" : change.FechaNacimiento.Substring(0, 10),
                    Genero = string.IsNullOrWhiteSpace(change.Genero) || change.Genero == last.Genero ? "" : change.Genero,

                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    Timestamp = change.Timestamp,
                    Who = change.Who
                };

                jsSlot.Id = HttpUtility.HtmlEncode(jsSlot.Id);
                jsSlot.Rut = HttpUtility.HtmlEncode(jsSlot.Rut);
                jsSlot.Nombre = HttpUtility.HtmlEncode(jsSlot.Nombre);
                jsSlot.ApellidoPaterno = HttpUtility.HtmlEncode(jsSlot.ApellidoPaterno);
                jsSlot.ApellidoMaterno = HttpUtility.HtmlEncode(jsSlot.ApellidoMaterno);
                jsSlot.FechaNacimiento = HttpUtility.HtmlEncode(jsSlot.FechaNacimiento);
                jsSlot.Genero = HttpUtility.HtmlEncode(jsSlot.Genero);

                list.Add(jsSlot);
                last = change;
            }

            return list;
        }

        private static void ClienteHistoryDeserializer(IEnumerable<History> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var historyData = JsonConvert.DeserializeObject<PersonaHistoryData>(e.Data);

                historyData.Timestamp = DateTime.Parse(historyData.Timestamp).ToString("yyyy'-'MM'-'dd' - 'HH':'mm':'ss");

                switch (e.MessageType)
                {
                    case "PersonaCrearEvent":
                        historyData.Action = HistoryDataEnum.REGISTERED.Name;
                        historyData.Who = e.User;
                        break;

                    case "PersonaModificarEvent":
                        historyData.Action = HistoryDataEnum.UPDATED.Name;
                        historyData.Who = e.User;
                        break;

                    case "PersonaEliminarEvent":
                        historyData.Action = HistoryDataEnum.REMOVED.Name;
                        historyData.Who = e.User;
                        break;

                    default:
                        historyData.Action = HistoryDataEnum.UNRECOGNIZED.Name;
                        historyData.Who = e.User ?? "Anonymous";
                        break;
                }

                HistoryData.Add(historyData);
            }
        }
    }
}
