using Dominio.Peliculas;
using Infraestructura.Persistencia.Repositorios;

namespace Infraestructura.Persistencia.Repositorios
{
    public class RepositorioPelicula : RepositorioGenerico<IdPelicula, Pelicula>, IRepositorioPelicula
    {
        public RepositorioPelicula(AplicacionContextoDb contexto) : base(contexto)
        {
        }

        public IQueryable<Pelicula> ListarTodasLasPeliculas() 
            => _dbSet
                .Include(p => p.Actores)
                .Include(p => p.Generos)
                .Include(t => t.Pais)
                .OrderBy(t => t.FechaDeCreacion);
    }
}
