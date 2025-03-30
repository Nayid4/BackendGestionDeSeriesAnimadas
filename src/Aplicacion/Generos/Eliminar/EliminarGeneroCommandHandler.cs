using Dominio.Generos;
using Dominio.Primitivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Aplicacion.Generos.Eliminar
{
    public sealed class EliminarGeneroCommandHandler : IRequestHandler<EliminarGeneroCommand, ErrorOr<Unit>>
    {
        private readonly IRepositorioGenero _repositorioGenero;
        private readonly IUnitOfWork _unitOfWork;

        public EliminarGeneroCommandHandler(IRepositorioGenero repositorioGenero, IUnitOfWork unitOfWork)
        {
            _repositorioGenero = repositorioGenero ?? throw new ArgumentNullException(nameof(repositorioGenero));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(EliminarGeneroCommand comando, CancellationToken cancellationToken)
        {
            if (await _repositorioGenero.ListarPorId(new IdGenero(comando.Id)) is not Genero genero)
            {
                return Error.NotFound("Genero.NoEncontrado", "No se encontro el genero.");
            }

            _repositorioGenero.Eliminar(genero);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
