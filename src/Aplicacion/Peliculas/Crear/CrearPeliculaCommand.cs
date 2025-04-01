using Aplicacion.Peliculas.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Peliculas.Crear
{
    public record CrearPeliculaCommand(
        ComandoPais Pais,
        ComandoDirector Director,
        string Titulo,
        string Resena,
        string ImagenDePortada,
        string CodigoDeTrailerEnYoutube,
        List<ComandoActor> Actores,
        List<ComandoGenero> Generos
    ) : IRequest<ErrorOr<Unit>>;
}
