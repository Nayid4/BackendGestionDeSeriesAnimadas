using Dominio.ActoresDePeliculas;
using Dominio.Directores;
using Dominio.Generos;
using Dominio.GenerosDePeliculas;
using Dominio.Paises;
using Dominio.Peliculas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Persistencia.Configuraciones
{
    public class ConfiguracionPelicula : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure(EntityTypeBuilder<Pelicula> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).HasConversion(
                gene => gene.Valor,
                valor => new IdPelicula(valor));

            builder.Property(t => t.IdPais).HasConversion(
                gene => gene.Valor,
                valor => new IdPais(valor));

            builder.Property(t => t.IdDirector).HasConversion(
                gene => gene.Valor,
                valor => new IdDirector(valor));

            builder.Property(t => t.Titulo)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne<Pais>()
                .WithMany()
                .HasForeignKey(t => t.IdPais);

            builder.HasOne<Director>()
                .WithMany()
                .HasForeignKey(t => t.IdDirector);

            builder.HasMany<GeneroDePelicula>()
                .WithOne()
                .HasForeignKey(t => t.IdPelicula);

            builder.HasMany<ActorDePelicula>()
                .WithOne()
                .HasForeignKey(t => t.IdPelicula);

            builder.Property(t => t.FechaDeCreacion);

            builder.Property(t => t.FechaDeActualizacion);
        }
    }
}
