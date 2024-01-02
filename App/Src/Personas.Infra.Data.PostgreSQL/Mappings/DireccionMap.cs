using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Personas.Domain.Entities;

namespace Personas.Infra.Data.PostgreSQL.Mappings
{
    public class DireccionMap : IEntityTypeConfiguration<Direccion>
    {
        public void Configure(EntityTypeBuilder<Direccion> builder)
        {
            builder.Property(c => c.Id).HasColumnName("Id").HasColumnType("UUID").IsRequired();
            builder.Property(c => c.IdPersona).HasColumnName("IdPersona").HasColumnType("UUID").IsRequired();
            builder.Property(c => c.Calle).HasColumnName("Calle").HasColumnType("varchar").HasMaxLength(200).IsRequired();
            builder.Property(c => c.Numero).HasColumnName("Numero").HasColumnType("varchar").HasMaxLength(10).IsRequired();
            builder.Property(c => c.NumeroCasaDepartamento).HasColumnName("NumeroCasaDepartamento").HasColumnType("varchar").HasMaxLength(10).IsRequired();
            builder.Property(c => c.Comuna).HasColumnName("Comuna").HasColumnType("varchar").HasMaxLength(100).IsRequired();
        }
    }
}
