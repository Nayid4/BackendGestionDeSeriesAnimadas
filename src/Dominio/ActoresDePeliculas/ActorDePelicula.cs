using Dominio.Actores;
using Dominio.Genericos;
using Dominio.Generos;
using Dominio.GenerosDePeliculas;
using Dominio.Peliculas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ActoresDePeliculas
{
    public sealed class ActorDePelicula : EntidadGenerica<IdActorDePelicula>
    {
        public IdActor IdActor { get; private set; } = default!;
        public IdPelicula IdPelicula { get; private set; } = default!;

        public Actor Actor { get; private set; } = default!;


        public ActorDePelicula() { }

        public ActorDePelicula(IdActorDePelicula id, IdActor idActor, IdPelicula idPelicula) : base(id)
        {
            IdActor = idActor ?? throw new ArgumentNullException(nameof(idActor));
            IdPelicula = idPelicula ?? throw new ArgumentNullException(nameof(idPelicula));
        }

        public void Actualizar(IdActor idActor, IdPelicula idPelicula)
        {
            IdActor = idActor ?? throw new ArgumentNullException(nameof(idActor));
            IdPelicula = idPelicula ?? throw new ArgumentNullException(nameof(idPelicula));
            FechaDeActualizacion = DateTime.Now;
        }
    }
}
