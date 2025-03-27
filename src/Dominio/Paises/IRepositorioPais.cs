using Dominio.Genericos;
using Dominio.Generos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Paises
{
    public interface IRepositorioPais : IRepositorioGenerico<IdPais, Pais>
    {
        Task<Pais?> ListarPorNombre(string nombre);
    }
}
