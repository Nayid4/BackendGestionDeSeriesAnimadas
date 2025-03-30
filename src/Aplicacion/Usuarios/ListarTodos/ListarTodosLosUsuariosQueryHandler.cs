using Aplicacion.Usuarios.Comun;
using Dominio.Paises;
using Dominio.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Usuarios.ListarTodos
{
    public sealed class ListarTodosLosUsuariosQueryHandler : IRequestHandler<ListarTodosLosUsuariosQuery, ErrorOr<IReadOnlyList<RespuestaUsuario>>>
    {
        private readonly IRepositorioPais _repositorioPais;
        private readonly IRepositorioUsuario _repositorioUsuario;

        public ListarTodosLosUsuariosQueryHandler(IRepositorioPais repositorioPais, IRepositorioUsuario repositorioUsuario)
        {
            _repositorioPais = repositorioPais ?? throw new ArgumentNullException(nameof(repositorioPais));
            _repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }

        public async Task<ErrorOr<IReadOnlyList<RespuestaUsuario>>> Handle(ListarTodosLosUsuariosQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _repositorioUsuario.ListarTodos()
                .Select(usuario => new RespuestaUsuario(
                    usuario.Id.Valor,
                    usuario.Nombre,
                    usuario.Apellido,
                    usuario.NombreDeUsuario
                ))
                .ToListAsync(cancellationToken);

            return usuarios;
        }
    }
}
