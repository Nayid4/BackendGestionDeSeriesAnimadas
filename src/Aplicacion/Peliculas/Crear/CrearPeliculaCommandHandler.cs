using Dominio.Actores;
using Dominio.ActoresDePeliculas;
using Dominio.Directores;
using Dominio.Generos;
using Dominio.GenerosDePeliculas;
using Dominio.Paises;
using Dominio.Peliculas;
using Dominio.Primitivos;
using System.Numerics;

namespace Aplicacion.Peliculas.Crear
{
    public sealed class CrearPeliculaCommandHandler : IRequestHandler<CrearPeliculaCommand, ErrorOr<Unit>>
    {
        private readonly IRepositorioPelicula _repositorioPelicula;
        private readonly IRepositorioActor _repositorioActor;
        private readonly IRepositorioDirector _repositorioDirector;
        private readonly IRepositorioPais _repositorioPais;
        private readonly IRepositorioGenero _repositorioGenero;
        private readonly IUnitOfWork _unitOfWork;

        public CrearPeliculaCommandHandler(IRepositorioPelicula repositorioPelicula, IRepositorioActor repositorioActor, IRepositorioDirector repositorioDirector, IRepositorioPais repositorioPais, IRepositorioGenero repositorioGenero, IUnitOfWork unitOfWork)
        {
            _repositorioPelicula = repositorioPelicula ?? throw new ArgumentNullException(nameof(repositorioPelicula));
            _repositorioActor = repositorioActor ?? throw new ArgumentNullException(nameof(repositorioActor));
            _repositorioDirector = repositorioDirector ?? throw new ArgumentNullException(nameof(repositorioDirector));
            _repositorioPais = repositorioPais ?? throw new ArgumentNullException(nameof(repositorioPais));
            _repositorioGenero = repositorioGenero ?? throw new ArgumentNullException(nameof(repositorioGenero));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(CrearPeliculaCommand comando, CancellationToken cancellationToken)
        {
            if (await _repositorioPais.ListarPorId(new IdPais(comando.IdPais)) is not Pais pais)
            {
                return Error.NotFound("Pais.NoEncontrada", "No se econtró el pais.");
            }

            if (await _repositorioDirector.ListarPorId(new IdDirector(comando.IdDirector)) is not Director director)
            {
                return Error.NotFound("Director.NoEncontrado", "No se econtró el director.");
            }

            var pelicula = new Pelicula(
                new IdPelicula(Guid.NewGuid()),
                pais.Id,
                director.Id,
                comando.Titulo,
                comando.Resena,
                comando.ImagenDePortada,
                comando.CodigoDeTrailerEnYoutube
            );

            var listaActores = new List<ActorDePelicula>();

            foreach (var actor in comando.Actores)
            {
                if (await _repositorioActor.ListarPorId(new IdActor(actor.Id)) is not Actor actor2)
                {
                    return Error.NotFound("Actor.NoEncontrado", "No se encontro el actor.");
                }

                var actorDePelicula = new ActorDePelicula(
                    new IdActorDePelicula(Guid.NewGuid()),
                    actor2.Id,
                    pelicula.Id
                );

                listaActores.Add(actorDePelicula);

            }

            var listaGeneros = new List<GeneroDePelicula>();

            foreach (var genero in comando.Generos)
            {
                if (await _repositorioGenero.ListarPorId(new IdGenero(genero.Id)) is not Genero genero2)
                {
                    return Error.NotFound("Genero.NoEncontrado", "No se encontro el genero.");
                }

                var generoDePelicula = new GeneroDePelicula(
                    new IdGeneroDePelicula(Guid.NewGuid()),
                    genero2.Id,
                    pelicula.Id
                );

                listaGeneros.Add(generoDePelicula);

            }

            pelicula.ActualizarActores(listaActores);
            pelicula.ActualizarGeneros(listaGeneros);

            _repositorioPelicula.Crear(pelicula);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
