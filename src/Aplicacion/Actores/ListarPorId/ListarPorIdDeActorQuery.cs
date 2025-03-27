using Aplicacion.Autores.Comun;
using Aplicacion.Directores.Comun;

namespace Aplicacion.Actores.ListarPorId
{
    public record ListarPorIdDeActorQuery(Guid Id) : IRequest<ErrorOr<RespuestaActor>>;
}
