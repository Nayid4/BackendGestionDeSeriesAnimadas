
using Dominio.Generos;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Datos
{
    public interface IAplicacionContextoDb
    {
        public DbSet<Genero> Genero { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
