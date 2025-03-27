using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Usuarios.Comun
{
    public record RespuestaIniciarSesion(
        string Token,
        string RefreshToken
    );
}
