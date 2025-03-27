using Dominio.Generos;
using Dominio.Primitivos;

namespace Aplicacion.Generos.Actualizar
{
    public sealed class ActualizarGeneroCommandHandler : IRequestHandler<ActualizarGeneroCommand, ErrorOr<Unit>>
    {
        private readonly IRepositorioGenero _repositorioGenero;
        private readonly IUnitOfWork _unitOfWork;

        public ActualizarGeneroCommandHandler(IRepositorioGenero repositorioGenero, IUnitOfWork unitOfWork)
        {
            _repositorioGenero = repositorioGenero ?? throw new ArgumentNullException(nameof(repositorioGenero));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(ActualizarGeneroCommand comando, CancellationToken cancellationToken)
        {
            if (await _repositorioGenero.ListarPorId(new IdGenero(comando.Id)) is not Genero genero)
            {
                return Error.NotFound("Genero.NoEncontrado", "No se encontro el genero.");
            }

            if (await _repositorioGenero.ListarPorNombre(comando.Nombre) is not Genero genero2)
            {
                return Error.Conflict("Genero.Encontrado", "Ya existe un genero con ese nombre.");
            }

            genero.Actualizar(comando.Nombre);

            _repositorioGenero.Actualizar(genero);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}
