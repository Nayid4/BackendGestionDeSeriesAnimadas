using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Peliculas.Eliminar
{
    public record EliminarPeliculaCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
}
