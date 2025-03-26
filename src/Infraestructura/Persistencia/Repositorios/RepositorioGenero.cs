using Dominio.Genericos;
using Dominio.Generos;
using Infraestructura.Persistencia;
using Infraestructura.Persistencia.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Persistencia.Repositorios
{
    public class RepositorioGenero : RepositorioGenerico<IdGenero, Genero>, IRepositorioGenero
    {
        public RepositorioGenero(AplicacionContextoDb contexto) : base(contexto)
        {
        }
    }
}
