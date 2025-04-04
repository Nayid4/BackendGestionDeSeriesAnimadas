﻿using Dominio.Usuarios;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Persistencia.Configuraciones
{
    public class ConfiguracionUsuario : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).HasConversion(
                gene => gene.Valor,
                valor => new IdUsuario(valor));

            builder.Property(t => t.Nombre)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.Apellido)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.NombreDeUsuario)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.Contrasena)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(t => t.FechaDeCreacion)
                .IsRequired();

            builder.Property(t => t.FechaDeActualizacion)
                .IsRequired();
        }
    }
}
