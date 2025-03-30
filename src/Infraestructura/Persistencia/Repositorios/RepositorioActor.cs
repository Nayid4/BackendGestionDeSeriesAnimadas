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

        public IQueryable<Actor> ListarTodosLosActores() => _dbSet.Include(t => t.Pais).OrderBy(t => t.FechaDeCreacion);
    }
}
