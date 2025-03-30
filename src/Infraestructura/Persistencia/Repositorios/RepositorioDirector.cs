using Dominio.Actores;
using Dominio.Directores;
using Infraestructura.Persistencia.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Persistencia.Repositorios
{
    public class RepositorioDirector : RepositorioGenerico<IdDirector, Director>, IRepositorioDirector
    {
        public RepositorioDirector(AplicacionContextoDb contexto) : base(contexto)
        {
        }

        public IQueryable<Director> ListarTodosLosDirectores() => _dbSet.Include(t => t.Pais).OrderBy(t => t.FechaDeCreacion);
    }
}
