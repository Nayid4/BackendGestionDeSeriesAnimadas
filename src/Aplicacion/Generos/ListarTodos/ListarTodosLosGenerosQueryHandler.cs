using Aplicacion.Generos.Comun;
using Dominio.Genericos;
using Dominio.Generos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Generos.ListarTodos
{
    public sealed class ListarTodosLosGenerosQueryHandler : IRequestHandler<ListarTodosLosGenerosQuery, ErrorOr<IReadOnlyList<RespuestaGenero>>>
    {
        private readonly IRepositorioGenero _repositorioGenero;

        public ListarTodosLosGenerosQueryHandler(IRepositorioGenero repositorioGenero)
        {
            _repositorioGenero = repositorioGenero ?? throw new ArgumentNullException(nameof(repositorioGenero));
        }

        public async Task<ErrorOr<IReadOnlyList<RespuestaGenero>>> Handle(ListarTodosLosGenerosQuery request, CancellationToken cancellationToken)
        {
            var generos = await _repositorioGenero.ListarTodos();

            var respuestaGeneros = generos.Select(ge => 
                new RespuestaGenero(
                    ge.Id.Valor, 
                    ge.Nombre
                )).ToList();

            return respuestaGeneros;
        }
    }
}
