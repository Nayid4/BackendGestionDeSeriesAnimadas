using Aplicacion.Datos;
using Dominio.Generos;
using Dominio.Primitivos;
using Infraestructura.Persistencia.Repositorios;
using Infraestructura.Persistencia;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Dominio.Paises;
using Dominio.Actores;
using Dominio.Directores;
using Dominio.Peliculas;
using Dominio.Usuarios;

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

            servicios.AddScoped<Dominio.Generos.IRepositorioGenero, RepositorioGenero>();
            servicios.AddScoped<Dominio.Paises.IRepositorioPais, RepositorioPais>();
            servicios.AddScoped<IRepositorioActor, RepositorioActor>();
            servicios.AddScoped<IRepositorioDirector, RepositorioDirector>();
            servicios.AddScoped<IRepositorioPelicula, RepositorioPelicula>();
            servicios.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

            return servicios;
        }

    }
}
