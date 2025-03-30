using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Generos.Eliminar
{
    public record EliminarGeneroCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
}
