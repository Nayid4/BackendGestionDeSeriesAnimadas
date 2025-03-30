using Aplicacion.Actores.Comun;
using Aplicacion.comun.ListarDatos;
using Aplicacion.Directores.Comun;
using Aplicacion.Paises.Comun;
using Aplicacion.Paises.ListarConFiltros;
using Dominio.Actores;
using Dominio.Directores;
using Dominio.Paises;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Aplicacion.Directores.ListarConFiltros
{
    public sealed class ListarConFiltrosDirectorQueryHandler : IRequestHandler<ListarConFiltrosDirectorQuery, ErrorOr<ListaPaginada<RespuestaDirector>>>
    {
        private readonly IRepositorioDirector _repositorioDirector;

        public ListarConFiltrosDirectorQueryHandler(IRepositorioDirector repositorioDirector)
        {
            _repositorioDirector = repositorioDirector ?? throw new ArgumentNullException(nameof(repositorioDirector));
        }
        public async Task<ErrorOr<ListaPaginada<RespuestaDirector>>> Handle(ListarConFiltrosDirectorQuery consulta, CancellationToken cancellationToken)
        {
            var directores = _repositorioDirector.ListarTodosLosDirectores();

            if (!string.IsNullOrWhiteSpace(consulta.TerminoDeBusqueda))
            {
                directores = directores.Where(at => 
                    at.Nombre.ToLower().Contains(consulta.TerminoDeBusqueda.ToLower()) ||
                    at.Apellido.ToLower().Contains(consulta.TerminoDeBusqueda.ToLower()) ||
                    at.Pais!.Nombre.ToLower().Contains(consulta.TerminoDeBusqueda.ToLower())
                );
            }

            if (consulta.OrdenarLista?.ToLower() == "desc")
            {
                directores = directores.OrderByDescending(ListarOrdenDePropiedad(consulta));
            } else
            {
                directores = directores.OrderBy(ListarOrdenDePropiedad(consulta));
            }



            var resultado = directores.Select(actor => new RespuestaDirector(
                    actor.Id.Valor,
                    actor.Nombre,
                    actor.Apellido,
                    actor.Pais!.Nombre
            ));

            var listaDeDirectores = await ListaPaginada<RespuestaDirector>.CrearAsync(
                    resultado,
                    consulta.Pagina,
                    consulta.TamanoPagina
                );

            return listaDeDirectores;

        }

        private static Expression<Func<Director, object>> ListarOrdenDePropiedad(ListarConFiltrosDirectorQuery consulta)
        {
            return consulta.OrdenarColumna?.ToLower() switch
            {
                "nombre" => actor => actor.Nombre,
                "apellido" => actor => actor.Apellido,
                "pais" => actor => actor.Pais!.Nombre,
                _ => actor => actor.Id
            };
        }

    }
}
