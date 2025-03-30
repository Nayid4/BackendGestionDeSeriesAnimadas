using Aplicacion.comun.ListarDatos;
using Aplicacion.Generos.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Generos.ListarConFiltros
{
    public record ListarConFiltrosGeneroQuery(
        string? TerminoDeBusqueda,
        string? OrdenarColumna,
        string? OrdenarLista,
        int Pagina,
        int TamanoPagina
    ) : IRequest<ErrorOr<ListaPaginada<RespuestaGenero>>>;
}
