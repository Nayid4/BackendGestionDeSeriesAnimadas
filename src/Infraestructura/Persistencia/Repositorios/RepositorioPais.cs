﻿using Dominio.Paises;
using Infraestructura.Persistencia.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Persistencia.Repositorios
{
    public class RepositorioPais : RepositorioGenerico<IdPais, Pais>, IRepositorioPais
    {
        public RepositorioPais(AplicacionContextoDb contexto) : base(contexto)
        {
        }

        public async Task<Pais?> ListarPorNombre(string nombre)
        {
            return await _dbSet.FirstOrDefaultAsync(p => p.Nombre == nombre);
        }
    }
}
