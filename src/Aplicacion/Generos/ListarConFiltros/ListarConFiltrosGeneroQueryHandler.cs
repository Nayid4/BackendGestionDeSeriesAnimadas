using Aplicacion.comun.ListarDatos;
using Aplicacion.Generos.Comun;
using Dominio.Generos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Generos.ListarConFiltros
{
    public sealed class ListarConFiltrosGeneroQueryHandler : IRequestHandler<ListarConFiltrosGeneroQuery, ErrorOr<ListaPaginada<RespuestaGenero>>>
    {
        private readonly IRepositorioGenero _repositorioGenero;

        public ListarConFiltrosGeneroQueryHandler(IRepositorioGenero repositorioGenero)
        {
            _repositorioGenero = repositorioGenero ?? throw new ArgumentNullException(nameof(repositorioGenero));
        }
        public async Task<ErrorOr<ListaPaginada<RespuestaGenero>>> Handle(ListarConFiltrosGeneroQuery consulta, CancellationToken cancellationToken)
        {
            var generos = _repositorioGenero.ListarTodos();

            if (!string.IsNullOrWhiteSpace(consulta.TerminoDeBusqueda))
            {
                generos = generos.Where(g => 
                    g.Nombre.ToLower().Contains(consulta.TerminoDeBusqueda.ToLower())
                );
            }

            if (consulta.OrdenarLista?.ToLower() == "desc")
            {
                generos = generos.OrderByDescending(ListarOrdenDePropiedad(consulta));
            } else
            {
                generos = generos.OrderBy(ListarOrdenDePropiedad(consulta));
            }

            var resultado = generos
                .Select(ge =>
                new RespuestaGenero(
                    ge.Id.Valor,
                    ge.Nombre
                ));

            var listaDeGeneros = await ListaPaginada<RespuestaGenero>.CrearAsync(
                    resultado,
                    consulta.Pagina,
                    consulta.TamanoPagina
                );

            return listaDeGeneros;

        }

        private static Expression<Func<Genero, object>> ListarOrdenDePropiedad(ListarConFiltrosGeneroQuery consulta)
        {
            return consulta.OrdenarColumna?.ToLower() switch
            {
                "nombre" => genero => genero.Nombre,
                _ => Genero => Genero.Id
            };

        }
    }
}
