﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Directores.Comun
{
    public record RespuestaDirector(
        Guid Id,
        string Nombre,
        string Apellido,
        string pais
    );
}
