using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Autores.Comun
{
    public record RespuestaActor(
        Guid Id,
        string Nombre,
        string Apellido,
        string pais
    );
}
