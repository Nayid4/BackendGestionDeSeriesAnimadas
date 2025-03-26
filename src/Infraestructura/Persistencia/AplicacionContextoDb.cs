
using Aplicacion.Datos;
using Dominio.Actores;
using Dominio.Directores;
using Dominio.Generos;
using Dominio.Paises;
using Dominio.Primitivos;

namespace Infraestructura.Persistencia
{
    public class AplicacionContextoDb : DbContext, IAplicacionContextoDb, IUnitOfWork
    {

        private readonly IPublisher _publisher;

        public DbSet<Genero> Genero { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Actor> Actor { get; set; }
        public DbSet<Director> Director { get; set; }

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
