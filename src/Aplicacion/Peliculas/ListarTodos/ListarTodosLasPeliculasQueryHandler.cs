using Aplicacion.Peliculas.Comun;
using Dominio.Actores;
using Dominio.Directores;
using Dominio.Generos;
using Dominio.Paises;
using Dominio.Peliculas;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Peliculas.ListarTodos
{
    public sealed class ListarTodosLasPeliculasQueryHandler : IRequestHandler<ListarTodosLasPeliculasQuery, ErrorOr<IReadOnlyList<RespuestaPelicula>>>
    {
        private readonly IRepositorioPelicula _repositorioPelicula;
        private readonly IRepositorioActor _repositorioActor;
        private readonly IRepositorioDirector _repositorioDirector;
        private readonly IRepositorioPais _repositorioPais;
        private readonly IRepositorioGenero _repositorioGenero;

        public ListarTodosLasPeliculasQueryHandler(IRepositorioPelicula repositorioPelicula, IRepositorioActor repositorioActor, IRepositorioDirector repositorioDirector, IRepositorioPais repositorioPais, IRepositorioGenero repositorioGenero)
        {
            _repositorioPelicula = repositorioPelicula ?? throw new ArgumentNullException(nameof(repositorioPelicula));
            _repositorioActor = repositorioActor ?? throw new ArgumentNullException(nameof(repositorioActor));
            _repositorioDirector = repositorioDirector ?? throw new ArgumentNullException(nameof(repositorioDirector));
            _repositorioPais = repositorioPais ?? throw new ArgumentNullException(nameof(repositorioPais));
            _repositorioGenero = repositorioGenero ?? throw new ArgumentNullException(nameof(repositorioGenero));
        }

        public async Task<ErrorOr<IReadOnlyList<RespuestaPelicula>>> Handle(ListarTodosLasPeliculasQuery request, CancellationToken cancellationToken)
        {
            var peliculas = await _repositorioPelicula
                .ListarTodasLasPeliculas()
                .Select(pelicula =>new RespuestaPelicula(
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

                ).ToListAsync(cancellationToken);


            return peliculas;
        }

    }
}
