﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Generos.Crear
{
    public record CrearGeneroCommand(string Nombre) : IRequest<ErrorOr<Unit>>;
}
