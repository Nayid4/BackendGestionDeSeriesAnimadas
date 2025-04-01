using Aplicacion.Peliculas.Comun;
using Dominio.Actores;
using Dominio.ActoresDePeliculas;
using Dominio.Directores;
using Dominio.Generos;
using Dominio.GenerosDePeliculas;
using Dominio.Paises;
using Dominio.Peliculas;
using Dominio.Primitivos;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Aplicacion.Peliculas.ListarPorId
{
    public sealed class ListarPorIdDePeliculaQueryHandler : IRequestHandler<ListarPorIdDePeliculaQuery, ErrorOr<RespuestaPelicula>>
    {
        private readonly IRepositorioPelicula _repositorioPelicula;
        private readonly IRepositorioActor _repositorioActor;
        private readonly IRepositorioDirector _repositorioDirector;
        private readonly IRepositorioPais _repositorioPais;
        private readonly IRepositorioGenero _repositorioGenero;

        public ListarPorIdDePeliculaQueryHandler(IRepositorioPelicula repositorioPelicula, IRepositorioActor repositorioActor, IRepositorioDirector repositorioDirector, IRepositorioPais repositorioPais, IRepositorioGenero repositorioGenero)
        {
            _repositorioPelicula = repositorioPelicula ?? throw new ArgumentNullException(nameof(repositorioPelicula));
            _repositorioActor = repositorioActor ?? throw new ArgumentNullException(nameof(repositorioActor));
            _repositorioDirector = repositorioDirector ?? throw new ArgumentNullException(nameof(repositorioDirector));
            _repositorioPais = repositorioPais ?? throw new ArgumentNullException(nameof(repositorioPais));
            _repositorioGenero = repositorioGenero ?? throw new ArgumentNullException(nameof(repositorioGenero));
        }

        public async Task<ErrorOr<RespuestaPelicula>> Handle(ListarPorIdDePeliculaQuery consulta, CancellationToken cancellationToken)
        {
            if (await _repositorioPelicula.ListarPorIdPelicula(new IdPelicula(consulta.Id)) is not Pelicula pelicula)
            {
                return Error.NotFound("Pelicula.NoEncontrada", "No se econtró la pelicula.");
            }


            var listaActores = new List<RespuestaActor>();

            foreach (var actor in pelicula.Actores)
            {
                if (await _repositorioActor.ListarPorId(actor.IdActor) is not Actor actor2)
                {
                    return Error.NotFound("Actor.NoEncontrado", "No se encontro el actor.");
                }

                var actorDePelicula = new RespuestaActor(
                    actor2.Id.Valor,
                    actor2.Nombre
                );

                listaActores.Add(actorDePelicula);
            }

            var listaGeneros = new List<RespuestaGenero>();

            foreach (var genero in pelicula.Generos)
            {
                if (await _repositorioGenero.ListarPorId(genero.IdGenero) is not Genero genero2)
                {
                    return Error.NotFound("Genero.NoEncontrado", "No se encontro el genero.");
                }

                var generoDePelicula = new RespuestaGenero(
                    genero2.Id.Valor,
                    genero2.Nombre
                );
                listaGeneros.Add(generoDePelicula);
            }

            if (await _repositorioPais.ListarPorId(pelicula.IdPais) is not Pais pais)
            {
                return Error.NotFound("Pais.NoEncontrada", "No se econtró el pais.");
            }

            if (await _repositorioDirector.ListarPorId(pelicula.IdDirector) is not Director director)
            {
                return Error.NotFound("Director.NoEncontrado", "No se econtró el director.");
            }

            var respuesta = new RespuestaPelicula(
                pelicula.Id.Valor,
                new RespuestaPais(
                    pais.Id.Valor, 
                    pais.Nombre
                ),
                new RespuestaDirector(
                    director.Id.Valor,
                    director.Nombre
                ),
                pelicula.Titulo,
                pelicula.Resena,
                pelicula.ImagenDePortada,
                pelicula.CodigoDeTrailerEnYoutube,
                listaActores,
                listaGeneros
                
            );

            return respuesta;
        }
    }
}
