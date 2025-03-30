using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Usuarios.Crear
{
    public record CrearUsuarioCommand(
        string Nombre, 
        string Apellido, 
        string NombreDeUsuario, 
        string Contrasena
    ) : IRequest<ErrorOr<Unit>>;
}
