﻿
using Aplicacion.Datos;
using Dominio.Actores;
using Dominio.ActoresDePeliculas;
using Dominio.Directores;
using Dominio.Generos;
using Dominio.GenerosDePeliculas;
using Dominio.Paises;
using Dominio.Peliculas;
using Dominio.Primitivos;
using Dominio.Usuarios;

namespace Infraestructura.Persistencia
{
    public class AplicacionContextoDb : DbContext, IAplicacionContextoDb, IUnitOfWork
    {

        private readonly IPublisher _publisher;

        public DbSet<Dominio.Generos.Genero> Genero { get; set; }
        public DbSet<Dominio.Paises.Pais> Pais { get; set; }
        public DbSet<Actor> Actor { get; set; }
        public DbSet<Director> Director { get; set; }
        public DbSet<Pelicula> Pelicula { get; set; }
        public DbSet<GeneroDePelicula> GeneroDePeliculas { get; set; }
        public DbSet<ActorDePelicula> ActorDePeliculas { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public AplicacionContextoDb(DbContextOptions options, IPublisher publisher) : base(options)
        {
            _publisher = publisher;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AplicacionContextoDb).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var eventosDeDominio = ChangeTracker.Entries<AggregateRoot>()
                .Select(e => e.Entity)
                .Where(e => e.GetDomainEvents().Any())
                .SelectMany(e => e.GetDomainEvents());

            var resultado = await base.SaveChangesAsync(cancellationToken);

            foreach (var evento in eventosDeDominio)
            {
                await _publisher.Publish(evento, cancellationToken);
            }

            return resultado;
        }
    }
}
