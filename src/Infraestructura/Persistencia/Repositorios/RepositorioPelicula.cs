using Dominio.Peliculas;
using Infraestructura.Persistencia.Repositorios;

namespace Infraestructura.Persistencia.Repositorios
{
    public class RepositorioPelicula : RepositorioGenerico<IdPelicula, Pelicula>, IRepositorioPelicula
    {
        public RepositorioPelicula(AplicacionContextoDb contexto) : base(contexto)
        {
        }
    }
}
