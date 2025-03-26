using Dominio.Genericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Usuarios
{
    public sealed class Usuario : EntidadGenerica<IdUsuario>
    {
        public string Nombre { get; private set; } = string.Empty;
        public string Apellido { get; private set; } = string.Empty;
        public string NombreDeUsuario { get; private set; } = string.Empty;
        public string Contrasena { get; private set; } = string.Empty;

        public Usuario() { }

        public Usuario(IdUsuario id, string nombre, string apellido, string nombreDeUsuario, string contrasena) : base(id)
        {
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            Apellido = apellido ?? throw new ArgumentNullException(nameof(apellido));
            NombreDeUsuario = nombreDeUsuario ?? throw new ArgumentNullException(nameof(nombreDeUsuario));
            Contrasena = contrasena ?? throw new ArgumentNullException(nameof(contrasena));
        }

        public void Actualizar(string nombre, string apellido, string nombreDeUsuario, string contrasena)
        {
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            Apellido = apellido ?? throw new ArgumentNullException(nameof(apellido));
            NombreDeUsuario = nombreDeUsuario ?? throw new ArgumentNullException(nameof(nombreDeUsuario));
            Contrasena = contrasena ?? throw new ArgumentNullException(nameof(contrasena));
            FechaDeActualizacion = DateTime.Now;
        }
    }
}
