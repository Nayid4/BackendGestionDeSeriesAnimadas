using Aplicacion.Directores.Comun;
using Aplicacion.Generos.Comun;
using Aplicacion.Paises.Comun;
using Dominio.Actores;
using Dominio.Directores;
using Dominio.Paises;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Aplicacion.Directores.ListarTodos
{
    public sealed class ListarTodosLosDirectoresQueryHandler : IRequestHandler<ListarTodosLosDirectoresQuery, ErrorOr<IReadOnlyList<RespuestaDirector>>>
    {
        private readonly IRepositorioPais _repositorioPais;
        private readonly IRepositorioDirector _repositorioDirector;

        public ListarTodosLosDirectoresQueryHandler(IRepositorioPais repositorioPais, IRepositorioDirector repositorioDirector)
        {
            _repositorioPais = repositorioPais ?? throw new ArgumentNullException(nameof(repositorioPais));
            _repositorioDirector = repositorioDirector ?? throw new ArgumentNullException(nameof(repositorioDirector));
        }

        public async Task<ErrorOr<IReadOnlyList<RespuestaDirector>>> Handle(ListarTodosLosDirectoresQuery request, CancellationToken cancellationToken)
        {
            var directores = await _repositorioDirector
                .ListarTodos()
                .Include(a => a.Pais)
                .ToListAsync(cancellationToken);


            var respuestaDirectores = directores.Select(director => new RespuestaDirector(
                    director.Id.Valor,
                    director.Nombre,
                    director.Apellido,
                    director.Pais!.Nombre
            )).ToList();

            return respuestaDirectores;
        }
    }
}
