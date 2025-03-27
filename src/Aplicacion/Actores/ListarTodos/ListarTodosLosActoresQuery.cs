
using Aplicacion.Autores.Comun;

namespace Aplicacion.Actores.ListarTodos
{
    public record ListarTodosLosActoresQuery() : IRequest<ErrorOr<IReadOnlyList<RespuestaActor>>>;
}
