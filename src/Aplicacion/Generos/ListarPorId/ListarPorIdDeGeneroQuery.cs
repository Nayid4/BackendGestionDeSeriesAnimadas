using Aplicacion.Generos.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Generos.ListarPorId
{
    public record ListarPorIdDeGeneroQuery(Guid Id) : IRequest<ErrorOr<RespuestaGenero>>;
}
