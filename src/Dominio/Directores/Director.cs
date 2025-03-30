using Dominio.Genericos;
using Dominio.Paises;
using Dominio.Personas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Directores
{
    public sealed class Director : Persona<IdDirector>
    {
        public Director()
        {
        }

        public Director(IdDirector id, string nombre, string apellido, IdPais idPais) : base(id, nombre, apellido, idPais)
        {
        }
    }
}
