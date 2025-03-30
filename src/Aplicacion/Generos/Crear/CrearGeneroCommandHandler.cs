using Dominio.Generos;
using Dominio.Primitivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Generos.Crear
{
    public sealed class CrearGeneroCommandHandler : IRequestHandler<CrearGeneroCommand, ErrorOr<Unit>>
    {
        private readonly IRepositorioGenero _repositorioGenero;
        private readonly IUnitOfWork _unitOfWork;

        public CrearGeneroCommandHandler(IRepositorioGenero repositorioGenero, IUnitOfWork unitOfWork)
        {
            _repositorioGenero = repositorioGenero ?? throw new ArgumentNullException(nameof(repositorioGenero));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(CrearGeneroCommand comando, CancellationToken cancellationToken)
        {
            if (await _repositorioGenero.ListarPorNombre(comando.Nombre) is Genero genero)
            {
                return Error.Conflict("Genero.Encontrado","Ya existe un genero con ese nombre.");
            }

            var nuedoGenero = new Genero(
                new IdGenero(Guid.NewGuid()),
                comando.Nombre
            );

            _repositorioGenero.Crear(nuedoGenero);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
