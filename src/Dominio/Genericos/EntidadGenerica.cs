using Dominio.Primitivos;

namespace Dominio.Genericos
{
    public abstract class EntidadGenerica<TID> : AggregateRoot
        where TID : IIdGenerico
    {
        
        public TID Id { get; protected set; } = default!;
        public string Nombre { get; protected set; } = string.Empty;
        public DateTime FechaDeCreacion { get; protected set; }
        public DateTime FechaDeActualizacion { get; protected set; }

        public EntidadGenerica()
        {
        }

        public EntidadGenerica(TID id, string nombre)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            FechaDeCreacion = DateTime.Now;
            FechaDeActualizacion = DateTime.Now;
        }

        
    }
}
