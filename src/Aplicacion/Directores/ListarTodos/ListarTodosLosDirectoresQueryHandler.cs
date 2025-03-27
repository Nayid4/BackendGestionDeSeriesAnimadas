using Aplicacion.Directores.Comun;
using Aplicacion.Generos.Comun;
using Aplicacion.Paises.Comun;
using Dominio.Directores;
using Dominio.Paises;
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
            var directores = await _repositorioDirector.ListarTodos();

            var respuestaDirectores = new List<RespuestaDirector>();

            foreach (var director in directores)
            {
                if (await _repositorioPais.ListarPorId(director.IdPais) is not Pais pais)
                {
                    return Error.NotFound("Pais.NoEncontrado", "No se encontro el pais.");
                }

                var datosDirector = new RespuestaDirector(
                    director.Id.Valor,
                    director.Nombre,
                    director.Apellido,
                    pais.Nombre
                );

                respuestaDirectores.Add( datosDirector );
            }

            return respuestaDirectores;
        }
    }
}
