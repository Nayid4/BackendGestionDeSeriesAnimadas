﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Usuarios.Eliminar
{
    public record EliminarUsuarioCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
}
