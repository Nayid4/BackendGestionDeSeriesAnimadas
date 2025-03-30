using Dominio.Actores;
using Dominio.ActoresDePeliculas;
using Dominio.Directores;
using Dominio.Genericos;
using Dominio.Generos;
using Dominio.GenerosDePeliculas;
using Dominio.Paises;
using System;
using System.Collections.Generic;

namespace Dominio.Peliculas
{
    public sealed class Pelicula : EntidadGenerica<IdPelicula>
    {
        private readonly HashSet<GeneroDePelicula> _generos = new();
        private readonly HashSet<ActorDePelicula> _actores = new();

        public IdPais IdPais { get; private set; } = default!;
        public IdDirector IdDirector { get; private set; } = default!;
        public string Titulo { get; private set; } = string.Empty;
        public string Resena { get; private set; } = string.Empty;
        public string ImagenDePortada { get; private set; } = string.Empty;
        public string CodigoDeTrailerEnYoutube { get; private set; } = string.Empty;

        public Pais? Pais { get; private set; }
        public Director? Director { get; private set; }

        public IReadOnlyCollection<GeneroDePelicula> Generos => _generos;
        public IReadOnlyCollection<ActorDePelicula> Actores => _actores;

        private Pelicula() { }

        public Pelicula(IdPelicula idPelicula, IdPais idPais, IdDirector idDirector, string titulo, string resena, string imagenDePortada, string codigoDeTrailerEnYoutube)
            : base(idPelicula)
        {
            IdPais = idPais ?? throw new ArgumentNullException(nameof(idPais));
            IdDirector = idDirector ?? throw new ArgumentNullException(nameof(idDirector));
            Titulo = titulo ?? throw new ArgumentNullException(nameof(titulo));
            Resena = resena ?? throw new ArgumentNullException(nameof(resena));
            ImagenDePortada = imagenDePortada ?? throw new ArgumentNullException(nameof(imagenDePortada));
            CodigoDeTrailerEnYoutube = codigoDeTrailerEnYoutube ?? throw new ArgumentNullException(nameof(codigoDeTrailerEnYoutube));
        }

        public void Actualizar(IdPais idPais, IdDirector idDirector, string titulo, string resena, string imagenDePortada, string codigoDeTrailerEnYoutube)
        {
            IdPais = idPais ?? throw new ArgumentNullException(nameof(idPais));
            IdDirector = idDirector ?? throw new ArgumentNullException(nameof(idDirector));
            Titulo = titulo ?? throw new ArgumentNullException(nameof(titulo));
            Resena = resena ?? throw new ArgumentNullException(nameof(resena));
            ImagenDePortada = imagenDePortada ?? throw new ArgumentNullException(nameof(imagenDePortada));
            CodigoDeTrailerEnYoutube = codigoDeTrailerEnYoutube ?? throw new ArgumentNullException(nameof(codigoDeTrailerEnYoutube));
        }

        public void AgregarGenero(GeneroDePelicula genero)
        {
            if (genero == null) throw new ArgumentNullException(nameof(genero));
            if (!_generos.Add(genero))
            {
                throw new InvalidOperationException("El género ya está agregado.");
            }
        }

        public void EliminarGenero(GeneroDePelicula genero)
        {
            if (genero == null) throw new ArgumentNullException(nameof(genero));
            if (!_generos.Remove(genero))
            {
                throw new InvalidOperationException("El género no está en la película.");
            }
        }

        public void ActualizarGeneros(List<GeneroDePelicula> nuevosGeneros)
        {
            var generosARemover = _generos.Except(nuevosGeneros).ToList();
            var generosAAgregar = nuevosGeneros.Except(_generos).ToList();

            foreach (var genero in generosARemover)
            {
                _generos.Remove(genero);
            }
            foreach (var genero in generosAAgregar)
            {
                _generos.Add(genero);
            }
        }

        public void AgregarActor(ActorDePelicula actor)
        {
            if (actor == null) throw new ArgumentNullException(nameof(actor));
            if (!_actores.Add(actor))
            {
                throw new InvalidOperationException("El actor ya está agregado.");
            }
        }

        public void EliminarActor(ActorDePelicula actor)
        {
            if (actor == null) throw new ArgumentNullException(nameof(actor));
            if (!_actores.Remove(actor))
            {
                throw new InvalidOperationException("El actor no está en la película.");
            }
        }

        public void ActualizarActores(List<ActorDePelicula> nuevosActores)
        {
            var actoresARemover = _actores.Except(nuevosActores).ToList();
            var actoresAAgregar = nuevosActores.Except(_actores).ToList();

            foreach (var actor in actoresARemover)
            {
                _actores.Remove(actor);
            }
            foreach (var actor in actoresAAgregar)
            {
                _actores.Add(actor);
            }
        }
    }
}
