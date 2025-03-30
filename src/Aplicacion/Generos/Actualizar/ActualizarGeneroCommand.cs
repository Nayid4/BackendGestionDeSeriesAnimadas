using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Generos.Actualizar
{
    public record ActualizarGeneroCommand(Guid Id, string Nombre) : IRequest<ErrorOr<Unit>>;
}
