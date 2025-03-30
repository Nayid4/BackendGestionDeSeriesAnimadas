using Dominio.Genericos;
using Dominio.Generos;
using Dominio.Paises;
using Infraestructura.Persistencia;
using Infraestructura.Persistencia.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Persistencia.Repositorios
{
    public class RepositorioGenero : RepositorioGenerico<IdGenero, Dominio.Generos.Genero>, Dominio.Generos.IRepositorioGenero
    {
        public RepositorioGenero(AplicacionContextoDb contexto) : base(contexto)
        {
        }

        public async Task<Dominio.Generos.Genero?> ListarPorNombre(string nombre)
        {
            return await _dbSet.FirstOrDefaultAsync(p => p.Nombre == nombre);
        }
    }
}
