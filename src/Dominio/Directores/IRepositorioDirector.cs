﻿using Dominio.Actores;
using Dominio.Genericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Directores
{
    public interface IRepositorioDirector : IRepositorioGenerico<IdDirector, Director>
    {
        IQueryable<Director> ListarTodosLosDirectores();
    }
}
