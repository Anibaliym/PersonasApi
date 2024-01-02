using Ardalis.SmartEnum;

namespace Personas.Domain.Enumerations.Persona
{
    public sealed class GeneroEnum : SmartEnum<GeneroEnum>
    {
        public static readonly GeneroEnum MASCULINO = new("MASCULINO", 1);
        public static readonly GeneroEnum FEMENINO = new("FEMENINO", 2);

        private GeneroEnum(string name, int value) : base(name, value) { }
    }
}
