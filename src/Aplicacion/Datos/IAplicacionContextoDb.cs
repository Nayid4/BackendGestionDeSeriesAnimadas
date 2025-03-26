
using Dominio.Actores;
using Dominio.Directores;
using Dominio.Generos;
using Dominio.Paises;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Datos
{
    public interface IAplicacionContextoDb
    {
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Actor> Actor {  get; set; }
        public DbSet<Director> Director { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
