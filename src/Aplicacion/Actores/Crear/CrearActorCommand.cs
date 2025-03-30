using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Actores.Crear
{
    public record CrearActorCommand(string Nombre, string Apellido, Guid IdPais) : IRequest<ErrorOr<Unit>>;
}
