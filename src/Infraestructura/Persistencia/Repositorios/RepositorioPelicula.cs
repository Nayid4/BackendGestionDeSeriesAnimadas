using Dominio.Peliculas;
using Infrastructura.Persistencia.Repositorios;

namespace Infraestructura.Persistencia.Repositorios
{
    public class RepositorioPelicula : RepositorioGenerico<IdPelicula, Pelicula>, IRepositorioPelicula
    {
        public RepositorioPelicula(AplicacionContextoDb contexto) : base(contexto)
        {
        }
    }
}
