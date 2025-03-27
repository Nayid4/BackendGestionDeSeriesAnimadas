using Aplicacion.Utilidades;
using Dominio.ObjetosDeValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Usuarios.DatosUsuario
{
    public sealed class DatosUsuariosQueryHandler : IRequestHandler<DatosUsuarioQuery, ErrorOr<DatosUsuarioDTO>>
    {
        private readonly IGestionToken _gestionToken;

        public DatosUsuariosQueryHandler(IGestionToken gestionToken)
        {
            _gestionToken = gestionToken ?? throw new ArgumentNullException(nameof(gestionToken));
        }

        public Task<ErrorOr<DatosUsuarioDTO>> Handle(DatosUsuarioQuery request, CancellationToken cancellationToken)
        {
            if (_gestionToken.DecodeJWT() is not DatosUsuarioDTO datosUsuario)
            {
                return Task.FromResult<ErrorOr<DatosUsuarioDTO>>(
                    Error.NotFound("Autenticacion.TokenNoEcontrado", "No se ha encontrado el token del usuario.")
                );
            }

            return Task.FromResult<ErrorOr<DatosUsuarioDTO>>(datosUsuario);
        }

    }
}
