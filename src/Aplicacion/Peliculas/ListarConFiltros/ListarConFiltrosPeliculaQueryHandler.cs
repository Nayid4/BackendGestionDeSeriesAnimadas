
using Aplicacion.comun.ListarDatos;
using Aplicacion.Paises.ListarConFiltros;
using Aplicacion.Peliculas.Comun;
using Dominio.Actores;
using Dominio.Paises;
using Dominio.Peliculas;
using Dominio.Usuarios;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Aplicacion.Peliculas.ListarConFiltros
{
    public sealed class ListarConFiltrosPeliculaQueryHandler : IRequestHandler<ListarConFiltrosPeliculaQuery, ErrorOr<ListaPaginada<RespuestaPelicula>>>
    {
        private readonly IRepositorioPelicula _repositorioPelicula;

        public ListarConFiltrosPeliculaQueryHandler(IRepositorioPelicula repositorioPelicula)
        {
            _repositorioPelicula = repositorioPelicula ?? throw new ArgumentNullException(nameof(repositorioPelicula));
        }
        public async Task<ErrorOr<ListaPaginada<RespuestaPelicula>>> Handle(ListarConFiltrosPeliculaQuery consulta, CancellationToken cancellationToken)
        {
            var peliculas = _repositorioPelicula.ListarTodasLasPeliculas();

            if (!string.IsNullOrWhiteSpace(consulta.TerminoDeBusqueda))
            {
                peliculas = peliculas.Where(at => 
                    at.Titulo.ToLower().Contains(consulta.TerminoDeBusqueda.ToLower()) ||
                    at.Resena.ToLower().Contains(consulta.TerminoDeBusqueda.ToLower()) ||
                    at.Pais!.Nombre.ToLower().Contains(consulta.TerminoDeBusqueda.ToLower()) ||
                    at.Director!.Nombre.ToLower().Contains(consulta.TerminoDeBusqueda.ToLower())
                );
            }

            if (consulta.OrdenarLista?.ToLower() == "desc")
            {
                peliculas = peliculas.OrderByDescending(ListarOrdenDePropiedad(consulta));
            } else
            {
                peliculas = peliculas.OrderBy(ListarOrdenDePropiedad(consulta));
            }



            var resultado = peliculas.Select(pelicula => new RespuestaPelicula(
                        pelicula.Id.Valor,
                        new RespuestaPais(pelicula.Id.Valor, pelicula.Pais!.Nombre),
                        new RespuestaDirector(pelicula.Id.Valor, pelicula.Director!.Nombre),
                        pelicula.Titulo,
                        pelicula.Resena,
                        pelicula.ImagenDePortada,
                        pelicula.CodigoDeTrailerEnYoutube,
                        pelicula.Actores.Select(
                            actor => new RespuestaActor(actor.IdActor.Valor, actor.Actor.Nombre)
                        ).ToList(),
                        pelicula.Generos.Select(
                            genero => new RespuestaGenero(genero.IdGenero.Valor, genero.Genero.Nombre)
                        ).ToList()
                    )

                );

            var listaDePeliculas = await ListaPaginada<RespuestaPelicula>.CrearAsync(
                    resultado,
                    consulta.Pagina,
                    consulta.TamanoPagina
                );

            return listaDePeliculas;

        }

        private static Expression<Func<Pelicula, object>> ListarOrdenDePropiedad(ListarConFiltrosPeliculaQuery consulta)
        {
            return consulta.OrdenarColumna?.ToLower() switch
            {
                "titulo" => pelicula => pelicula.Titulo,
                "pais" => pelicula => pelicula.Pais!.Nombre,
                "director" => pelicula => pelicula.Director!.Nombre,
                _ => pelicula => pelicula.Id
            };
        }

    }
}
