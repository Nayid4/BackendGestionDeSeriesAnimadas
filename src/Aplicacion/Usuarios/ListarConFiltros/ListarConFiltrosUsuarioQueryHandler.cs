using Aplicacion.Actores.Comun;
using Aplicacion.comun.ListarDatos;
using Aplicacion.Directores.Comun;
using Aplicacion.Paises.Comun;
using Aplicacion.Paises.ListarConFiltros;
using Aplicacion.Usuarios.Comun;
using Dominio.Actores;
using Dominio.Paises;
using Dominio.Usuarios;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Aplicacion.Usuarios.ListarConFiltros
{
    public sealed class ListarConFiltrosUsuarioQueryHandler : IRequestHandler<ListarConFiltrosUsuarioQuery, ErrorOr<ListaPaginada<RespuestaUsuario>>>
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public ListarConFiltrosUsuarioQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }
        public async Task<ErrorOr<ListaPaginada<RespuestaUsuario>>> Handle(ListarConFiltrosUsuarioQuery consulta, CancellationToken cancellationToken)
        {
            var usuarios = _repositorioUsuario.ListarTodos();

            if (!string.IsNullOrWhiteSpace(consulta.TerminoDeBusqueda))
            {
                usuarios = usuarios.Where(at => 
                    at.Nombre.ToLower().Contains(consulta.TerminoDeBusqueda.ToLower()) ||
                    at.Apellido.ToLower().Contains(consulta.TerminoDeBusqueda.ToLower()) ||
                    at.NombreDeUsuario.ToLower().Contains(consulta.TerminoDeBusqueda.ToLower())
                );
            }

            if (consulta.OrdenarLista?.ToLower() == "desc")
            {
                usuarios = usuarios.OrderByDescending(ListarOrdenDePropiedad(consulta));
            } else
            {
                usuarios = usuarios.OrderBy(ListarOrdenDePropiedad(consulta));
            }



            var resultado = usuarios.Select(actor => new RespuestaUsuario(
                    actor.Id.Valor,
                    actor.Nombre,
                    actor.Apellido,
                    actor.NombreDeUsuario
            ));

            var listaDeUsuarios = await ListaPaginada<RespuestaUsuario>.CrearAsync(
                    resultado,
                    consulta.Pagina,
                    consulta.TamanoPagina
                );

            return listaDeUsuarios;

        }

        private static Expression<Func<Usuario, object>> ListarOrdenDePropiedad(ListarConFiltrosUsuarioQuery consulta)
        {
            return consulta.OrdenarColumna?.ToLower() switch
            {
                "nombre" => actor => actor.Nombre,
                "apellido" => actor => actor.Apellido,
                "nombreDeUsuario" => actor => actor.NombreDeUsuario,
                _ => actor => actor.Id
            };
        }

    }
}
