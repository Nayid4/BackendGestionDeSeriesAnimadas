using Aplicacion.Generos.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Generos.ListarTodos
{
    public record ListarTodosLosGenerosQuery() : IRequest<ErrorOr<IReadOnlyList<RespuestaGenero>>>;
}
