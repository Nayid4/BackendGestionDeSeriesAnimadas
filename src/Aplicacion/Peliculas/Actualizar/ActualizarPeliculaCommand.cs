using Aplicacion.Peliculas.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Peliculas.Actualizar
{
    public record ActualizarPeliculaCommand(
        Guid Id,
        Guid IdPais,
        Guid IdDirector,
        string Titulo,
        string Resena,
        string ImagenDePortada,
        string CodigoDeTrailerEnYoutube,
        List<ComandoActor> Actores,
        List<ComandoGenero> Generos
    ) : IRequest<ErrorOr<Unit>>;
}
