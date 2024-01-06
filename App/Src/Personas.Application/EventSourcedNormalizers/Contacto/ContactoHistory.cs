using Newtonsoft.Json;
using Personas.Domain.Core.Enumerations;
using Personas.Domain.Core.Events;
using System.Web;

namespace Personas.Application.EventSourcedNormalizers.Contacto
{
    public static class ContactoHistory
    {
        public static IList<ContactoHistoryData> HistoryData { get; set; }

        public static IList<ContactoHistoryData> ToJavaScriptCustomerHistory(IList<History> storedEvents)
        {
            HistoryData = new List<ContactoHistoryData>();
            ClienteHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.Timestamp);
            var list = new List<ContactoHistoryData>();
            var last = new ContactoHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new ContactoHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id ? "" : change.Id,
                    IdPersona = change.IdPersona == Guid.Empty.ToString() || change.IdPersona == last.IdPersona ? "" : change.IdPersona,
                    Celular = string.IsNullOrWhiteSpace(change.Celular) || change.Celular == last.Celular ? "" : change.Celular,
                    Email = string.IsNullOrWhiteSpace(change.Email) || change.Email == last.Email ? "" : change.Email,
                    TipoContacto = string.IsNullOrWhiteSpace(change.TipoContacto) || change.TipoContacto == last.TipoContacto ? "" : change.TipoContacto,

                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    Timestamp = change.Timestamp,
                    Who = change.Who
                };

                jsSlot.Id = HttpUtility.HtmlEncode(jsSlot.Id);
                jsSlot.IdPersona = HttpUtility.HtmlEncode(jsSlot.IdPersona);
                jsSlot.Celular = HttpUtility.HtmlEncode(jsSlot.Celular);
                jsSlot.Email = HttpUtility.HtmlEncode(jsSlot.Email);
                jsSlot.TipoContacto = HttpUtility.HtmlEncode(jsSlot.TipoContacto);

                list.Add(jsSlot);
                last = change;
            }

            return list;
        }

        private static void ClienteHistoryDeserializer(IEnumerable<History> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var historyData = JsonConvert.DeserializeObject<ContactoHistoryData>(e.Data);

                historyData.Timestamp = DateTime.Parse(historyData.Timestamp).ToString("yyyy'-'MM'-'dd' - 'HH':'mm':'ss");

                switch (e.MessageType)
                {
                    case "ContactoCrearEvent":
                        historyData.Action = HistoryDataEnum.REGISTERED.Name;
                        historyData.Who = e.User;
                        break;

                    case "ContactoModificarEvent":
                        historyData.Action = HistoryDataEnum.UPDATED.Name;
                        historyData.Who = e.User;
                        break;

                    case "ContactoEliminarEvent":
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
