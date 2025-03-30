using Dominio.Peliculas;
using Dominio.Primitivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Aplicacion.Peliculas.Eliminar
{
    public sealed class EliminarPeliculaCommandHandler : IRequestHandler<EliminarPeliculaCommand, ErrorOr<Unit>>
    {
        private readonly IRepositorioPelicula _repositorioPelicula;
        private readonly IUnitOfWork _unitOfWork;

        public EliminarPeliculaCommandHandler(IRepositorioPelicula repositorioPelicula, IUnitOfWork unitOfWork)
        {
            _repositorioPelicula = repositorioPelicula ?? throw new ArgumentNullException(nameof(repositorioPelicula));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(EliminarPeliculaCommand comando, CancellationToken cancellationToken)
        {
            if (await _repositorioPelicula.ListarPorId(new IdPelicula(comando.Id)) is not Pelicula pelicula)
            {
                return Error.NotFound("Pelicula.NoEncontrada", "No se econtró la pelicula.");
            }

            _repositorioPelicula.Eliminar(pelicula);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
