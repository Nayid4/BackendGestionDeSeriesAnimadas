using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Actores.Actualizar
{
    public record ActualizarActorCommand(Guid Id, string Nombre, string Apellido, Guid IdPais) : IRequest<ErrorOr<Unit>>;
}
