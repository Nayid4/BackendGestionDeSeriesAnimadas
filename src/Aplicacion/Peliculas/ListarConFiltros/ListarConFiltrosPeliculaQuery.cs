using Aplicacion.Actores.Comun;
using Aplicacion.comun.ListarDatos;
using Aplicacion.Paises.Comun;
using Aplicacion.Peliculas.Comun;

namespace Aplicacion.Peliculas.ListarConFiltros
{
    public record ListarConFiltrosPeliculaQuery(
        string? TerminoDeBusqueda,
        string? OrdenarColumna,
        string? OrdenarLista,
        int Pagina,
        int TamanoPagina
    ) : IRequest<ErrorOr<ListaPaginada<RespuestaPelicula>>>;
}
