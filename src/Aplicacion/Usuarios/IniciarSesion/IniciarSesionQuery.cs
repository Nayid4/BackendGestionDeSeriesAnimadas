using Aplicacion.Usuarios.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Usuarios.IniciarSesion
{
    public record IniciarSesionQuery(string NombreDeUsuario, string Contrasena) : IRequest<ErrorOr<RespuestaIniciarSesion>>;
}
