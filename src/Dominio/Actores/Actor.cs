using Dominio.Genericos;
using Dominio.Paises;
using Dominio.Personas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Actores
{
    public sealed class Actor : Persona<IdActor>
    {
        public Actor()
        {
        }

        public Actor(IdActor id, string nombre, string apellido, IdPais idPais) : base(id, nombre, apellido, idPais)
        {
        }
    }
}
