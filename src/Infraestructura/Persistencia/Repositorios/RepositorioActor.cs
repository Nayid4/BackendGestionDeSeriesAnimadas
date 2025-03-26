using Dominio.Actores;
using Infraestructura.Persistencia.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Persistencia.Repositorios
{
    public class RepositorioActor : RepositorioGenerico<IdActor, Actor>, IRepositorioActor
    {
        public RepositorioActor(AplicacionContextoDb contexto) : base(contexto)
        {
        }
    }
}
