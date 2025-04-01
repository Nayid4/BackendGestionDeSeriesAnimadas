using Dominio.Peliculas;
using Infraestructura.Persistencia.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Persistencia.Repositorios
{
    public class RepositorioPelicula : RepositorioGenerico<IdPelicula, Pelicula>, IRepositorioPelicula
    {
        public RepositorioPelicula(AplicacionContextoDb contexto) : base(contexto)
        {
        }

        public async Task<Pelicula?> ListarPorIdPelicula(IdPelicula id)
            => await _dbSet
                .Include(p => p.Actores)
                .Include(p => p.Generos)
                .Include(t => t.Pais)
                .FirstOrDefaultAsync(t => t.Id == id);

        public IQueryable<Pelicula> ListarTodasLasPeliculas() 
            => _dbSet
                .Include(p => p.Actores)
                .Include(p => p.Generos)
                .Include(t => t.Pais)
                .OrderBy(t => t.FechaDeCreacion);
    }
}
