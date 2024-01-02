using Ardalis.SmartEnum;

namespace Personas.Domain.Core.Enumerations
{
    public sealed class HistoryDataEnum : SmartEnum<HistoryDataEnum>
    {
        public static readonly HistoryDataEnum REGISTERED = new("REGISTERED", 1);
        public static readonly HistoryDataEnum UPDATED = new("UPDATED", 2);
        public static readonly HistoryDataEnum REMOVED = new("REMOVED", 3);
        public static readonly HistoryDataEnum UNRECOGNIZED = new("UNRECOGNIZED", 4);

        private HistoryDataEnum(string name, int value) : base(name, value) { }
    }
}
