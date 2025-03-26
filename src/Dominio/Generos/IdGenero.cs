using Dominio.Genericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Generos
{
    public record IdGenero(Guid Valor) : IIdGenerico;
}
