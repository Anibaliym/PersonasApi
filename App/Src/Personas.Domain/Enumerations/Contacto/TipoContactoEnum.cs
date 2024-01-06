using Ardalis.SmartEnum;

namespace Personas.Domain.Enumerations.Contacto
{
    public sealed class TipoContactoEnum : SmartEnum<TipoContactoEnum>
    {
        public static readonly TipoContactoEnum PARTICULAR = new("PARTICULAR", 1);
        public static readonly TipoContactoEnum LABORAL = new("LABORAL", 2);

        private TipoContactoEnum(string name, int value) : base(name, value) { }
    }
}
