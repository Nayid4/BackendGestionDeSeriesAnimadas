using Aplicacion.Autores.Comun;
using Aplicacion.Directores.Comun;
using Aplicacion.Generos.Comun;
using Aplicacion.Paises.Comun;
using Dominio.Actores;
using Dominio.Directores;
using Dominio.Paises;
using System.IO;

namespace Aplicacion.Actores.ListarTodos
{
    public sealed class ListarTodosLosActoresQueryHandler : IRequestHandler<ListarTodosLosActoresQuery, ErrorOr<IReadOnlyList<RespuestaActor>>>
    {
        private readonly IRepositorioPais _repositorioPais;
        private readonly IRepositorioActor _repositorioActor;

        public ListarTodosLosActoresQueryHandler(IRepositorioPais repositorioPais, IRepositorioActor repositorioActor)
        {
            _repositorioPais = repositorioPais ?? throw new ArgumentNullException(nameof(repositorioPais));
            _repositorioActor = repositorioActor ?? throw new ArgumentNullException(nameof(repositorioActor));
        }

        public async Task<ErrorOr<IReadOnlyList<RespuestaActor>>> Handle(ListarTodosLosActoresQuery request, CancellationToken cancellationToken)
        {
            var actores = await _repositorioActor.ListarTodos();

            var respuestaActores = new List<RespuestaActor>();

            foreach (var actor in actores)
            {
                if (await _repositorioPais.ListarPorId(actor.IdPais) is not Pais pais)
                {
                    return Error.NotFound("Pais.NoEncontrado", "No se encontro el pais.");
                }

                var datosActor = new RespuestaActor(
                    actor.Id.Valor,
                    actor.Nombre,
                    actor.Apellido,
                    pais.Nombre
                );

                respuestaActores.Add( datosActor );
            }

            return respuestaActores;
        }
    }
}
