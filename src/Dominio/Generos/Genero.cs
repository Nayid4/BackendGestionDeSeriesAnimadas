using Dominio.Genericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Generos
{
    public sealed class Genero : EntidadGenerica<IdGenero>
    {
        public Genero()
        {
        }

        public Genero(IdGenero id, string nombre) 
            : base(id, nombre)
        {
        }

        public void Actualizar(string nombre)
        {
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            FechaDeActualizacion = DateTime.Now;
        }
    }
}
