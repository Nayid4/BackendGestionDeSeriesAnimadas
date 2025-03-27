using Aplicacion.Generos.Comun;
using Dominio.Generos;

namespace Aplicacion.Generos.ListarPorId
{
    public sealed class ListarPorIdDeGeneroQueryHandler : IRequestHandler<ListarPorIdDeGeneroQuery, ErrorOr<RespuestaGenero>>
    {
        private readonly IRepositorioGenero _repositorioGenero;

        public ListarPorIdDeGeneroQueryHandler(IRepositorioGenero repositorioGenero)
        {
            _repositorioGenero = repositorioGenero ?? throw new ArgumentNullException(nameof(repositorioGenero));
        }

        public async Task<ErrorOr<RespuestaGenero>> Handle(ListarPorIdDeGeneroQuery consulta, CancellationToken cancellationToken)
        {
            if (await _repositorioGenero.ListarPorId(new IdGenero(consulta.Id)) is not Genero genero)
            {
                return Error.NotFound("Genero.NoEncontrado", "No se encontro el genero.");
            }

            var respuesta = new RespuestaGenero(genero.Id.Valor, genero.Nombre);

            return respuesta;
        }
    }
}
