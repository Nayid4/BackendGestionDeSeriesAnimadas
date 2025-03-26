using Aplicacion.Datos;
using Dominio.Generos;
using Dominio.Primitivos;
using Infraestructura.Persistencia.Repositorios;
using Infraestructura.Persistencia;
using Infrastructura.Persistencia.Repositorios;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructura.Servicios
{
    public static class InyeccionDeDependencias
    {
        public static IServiceCollection AddInfraestructura(this IServiceCollection servicios, IConfiguration configuracion)
        {
            servicios.AgregarPersistencias(configuracion);
            return servicios;
        }

        public static IServiceCollection AgregarPersistencias(this IServiceCollection servicios, IConfiguration configuracion)
        {
            servicios.AddDbContext<AplicacionContextoDb>(options =>
                options.UseSqlServer(configuracion.GetConnectionString("Database"), sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: null);
                }));

            servicios.AddScoped<IAplicacionContextoDb>(sp =>
                sp.GetRequiredService<AplicacionContextoDb>());

            servicios.AddScoped<IUnitOfWork>(sp =>
                sp.GetRequiredService<AplicacionContextoDb>());

            servicios.AddScoped<IRepositorioGenero, RepositorioGenero>();

            return servicios;
        }

    }
}
