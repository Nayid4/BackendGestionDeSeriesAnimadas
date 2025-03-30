using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Peliculas.Comun
{
    public record RespuestaPelicula(
        Guid Id,
        RespuestaPais Pais,
        RespuestaDirector Director,
        string Titulo,
        string Resena,
        string ImagenDePortada,
        string CodigoDeTrailerEnYoutube,
        List<RespuestaActor> Actores,
        List<RespuestaGenero> Generos
    );

    public record RespuestaPais(
        Guid Id,
        string Nombre
    );

    public record RespuestaDirector(
        Guid Id,
        string Nombre
    );

    public record RespuestaActor(
        Guid Id,
        string Nombre
    );

    public record RespuestaGenero(
        Guid Id,
        string Nombre
    );

}
