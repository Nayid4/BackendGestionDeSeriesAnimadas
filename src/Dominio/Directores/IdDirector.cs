using Dominio.Genericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Directores
{
    public record IdDirector(Guid Valor) : IIdGenerico;
}
