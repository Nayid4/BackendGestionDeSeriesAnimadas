using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Directores.Actualizar
{
    public record ActualizarDirectorCommand(Guid Id, string Nombre, string Apellido, Guid IdPais) : IRequest<ErrorOr<Unit>>;
}
