using Aplicacion.Autores.Comun;
using Aplicacion.Directores.Comun;
using Aplicacion.Usuarios.Comun;

namespace Aplicacion.Usuarios.ListarPorId
{
    public record ListarPorIdDeUsuarioQuery(Guid Id) : IRequest<ErrorOr<RespuestaUsuario>>;
}
