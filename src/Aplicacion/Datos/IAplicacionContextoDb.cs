
using Dominio.Actores;
using Dominio.ActoresDePeliculas;
using Dominio.Directores;
using Dominio.Generos;
using Dominio.GenerosDePeliculas;
using Dominio.Paises;
using Dominio.Peliculas;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Datos
{
    public interface IAplicacionContextoDb
    {
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Actor> Actor {  get; set; }
        public DbSet<Director> Director { get; set; }
        public DbSet<Pelicula> Pelicula { get; set; }
        public DbSet<GeneroDePelicula> GeneroDePeliculas { get; set; }
        public DbSet<ActorDePelicula> ActorDePeliculas { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
