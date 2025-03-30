using Aplicacion.Peliculas.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Peliculas.ListarTodos
{
    public record ListarTodosLasPeliculasQuery() : IRequest<ErrorOr<IReadOnlyList<RespuestaPelicula>>>;
}
