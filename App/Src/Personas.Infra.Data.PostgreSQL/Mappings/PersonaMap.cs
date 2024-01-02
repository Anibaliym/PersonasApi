using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Personas.Domain.Entities;

namespace Personas.Infra.Data.PostgreSQL.Mappings
{
    public class PersonaMap : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.Property(c => c.Id).HasColumnName("Id").HasColumnType("UUID").IsRequired();
            builder.Property(c => c.Rut).HasColumnName("Rut").HasColumnType("varchar").HasMaxLength(8).IsRequired();
            builder.Property(c => c.Nombre).HasColumnName("Nombre").HasColumnType("varchar").HasMaxLength(200).IsRequired();
            builder.Property(c => c.ApellidoPaterno).HasColumnName("ApellidoPaterno").HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(c => c.ApellidoMaterno).HasColumnName("ApellidoMaterno").HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(c => c.FechaNacimiento).HasColumnName("FechaNacimiento").HasColumnType("timestamp");
            builder.Property(c => c.Genero).HasColumnName("Genero").HasColumnType("varchar").HasMaxLength(10).IsRequired();
        }
    }
}
