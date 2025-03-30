using Dominio.Genericos;
using Dominio.Generos;
using Dominio.Peliculas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.GenerosDePeliculas
{
    public sealed class GeneroDePelicula : EntidadGenerica<IdGeneroDePelicula>
    {
        public IdGenero IdGenero { get; private set; } = default!;
        public IdPelicula IdPelicula { get; private set; } = default!;

        public Genero Genero { get; private set; } = default!;

        public GeneroDePelicula() { }

        public GeneroDePelicula(IdGeneroDePelicula id, IdGenero idGenero, IdPelicula idPelicula) : base(id)
        {
            IdGenero = idGenero ?? throw new ArgumentNullException(nameof(idGenero));
            IdPelicula = idPelicula ?? throw new ArgumentNullException(nameof(idPelicula));
        }

        public void Actualizar(IdGenero idGenero, IdPelicula idPelicula)
        {
            IdGenero = idGenero ?? throw new ArgumentNullException(nameof(idGenero));
            IdPelicula = idPelicula ?? throw new ArgumentNullException(nameof(idPelicula));
            FechaDeActualizacion = DateTime.Now;
        }
    }
}
