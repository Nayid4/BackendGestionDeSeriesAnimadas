using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Usuarios.Actualizar
{
    public record ActualizarUsuarioCommand(
        Guid Id, 
        string Nombre, 
        string Apellido, 
        string NombreDeUsuario,
        string Contrasena
    ) : IRequest<ErrorOr<Unit>>;
}
