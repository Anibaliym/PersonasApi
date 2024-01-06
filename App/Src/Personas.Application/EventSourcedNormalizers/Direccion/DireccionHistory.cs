using Newtonsoft.Json;
using Personas.Domain.Core.Enumerations;
using Personas.Domain.Core.Events;
using System.Web;

namespace Personas.Application.EventSourcedNormalizers.Direccion
{
    public static class DireccionHistory
    {
        public static IList<DireccionHistoryData> HistoryData { get; set; }

        public static IList<DireccionHistoryData> ToJavaScriptCustomerHistory(IList<History> storedEvents)
        {
            HistoryData = new List<DireccionHistoryData>();
            ClienteHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.Timestamp);
            var list = new List<DireccionHistoryData>();
            var last = new DireccionHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new DireccionHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id ? "" : change.Id,
                    IdPersona = change.IdPersona == Guid.Empty.ToString() || change.IdPersona == last.IdPersona ? "" : change.IdPersona,
                    Calle = string.IsNullOrWhiteSpace(change.Calle) || change.Calle == last.Calle ? "" : change.Calle,
                    Numero = string.IsNullOrWhiteSpace(change.Numero) || change.Numero == last.Numero ? "" : change.Numero,
                    NumeroCasaDepartamento = string.IsNullOrWhiteSpace(change.NumeroCasaDepartamento) || change.NumeroCasaDepartamento == last.NumeroCasaDepartamento ? "" : change.NumeroCasaDepartamento,
                    Comuna = string.IsNullOrWhiteSpace(change.Comuna) || change.Comuna == last.Comuna ? "" : change.Comuna,

                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    Timestamp = change.Timestamp,
                    Who = change.Who
                };

                jsSlot.Id = HttpUtility.HtmlEncode(jsSlot.Id);
                jsSlot.IdPersona = HttpUtility.HtmlEncode(jsSlot.IdPersona);
                jsSlot.Calle = HttpUtility.HtmlEncode(jsSlot.Calle);
                jsSlot.Numero = HttpUtility.HtmlEncode(jsSlot.Numero);
                jsSlot.NumeroCasaDepartamento = HttpUtility.HtmlEncode(jsSlot.NumeroCasaDepartamento);
                jsSlot.Comuna = HttpUtility.HtmlEncode(jsSlot.Comuna);

                list.Add(jsSlot);
                last = change;
            }

            return list;
        }

        private static void ClienteHistoryDeserializer(IEnumerable<History> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var historyData = JsonConvert.DeserializeObject<DireccionHistoryData>(e.Data);

                historyData.Timestamp = DateTime.Parse(historyData.Timestamp).ToString("yyyy'-'MM'-'dd' - 'HH':'mm':'ss");

                switch (e.MessageType)
                {
                    case "DireccionCrearEvent":
                        historyData.Action = HistoryDataEnum.REGISTERED.Name;
                        historyData.Who = e.User;
                        break;

                    case "DireccionModificarEvent":
                        historyData.Action = HistoryDataEnum.UPDATED.Name;
                        historyData.Who = e.User;
                        break;

                    case "DireccionEliminarEvent":
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
