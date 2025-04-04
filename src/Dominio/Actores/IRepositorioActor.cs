﻿using Dominio.Genericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Actores
{
    public interface IRepositorioActor : IRepositorioGenerico<IdActor, Actor>
    {
        IQueryable<Actor> ListarTodosLosActores();
    }
}
