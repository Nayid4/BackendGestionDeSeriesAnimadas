﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Peliculas.Comun
{

    public record ComandoActor(
        Guid Id
    );

    public record ComandoGenero(
        Guid Id
    );
}
