using Dominio.Genericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Peliculas
{
    public record IdPelicula(Guid Valor) : IIdGenerico;
}
