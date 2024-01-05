using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Personas.Domain.Entities;

namespace Personas.Infra.Data.PostgreSQL.Mappings
{
    public class ContactoMap : IEntityTypeConfiguration<Contacto>
    {
        public void Configure(EntityTypeBuilder<Contacto> builder)
        {
            builder.Property(c => c.Id).HasColumnName("Id").HasColumnType("UUID").IsRequired();
            builder.Property(c => c.IdPersona).HasColumnName("IdPersona").HasColumnType("UUID").IsRequired();
            builder.Property(c => c.Celular).HasColumnName("Celular").HasColumnType("varchar").HasMaxLength(13).IsRequired();
            builder.Property(c => c.Email).HasColumnName("Email").HasColumnType("varchar").HasMaxLength(200).IsRequired();
            builder.Property(c => c.TipoContacto).HasColumnName("TipoContacto").HasColumnType("varchar").HasMaxLength(20).IsRequired();
        }
    }
}
