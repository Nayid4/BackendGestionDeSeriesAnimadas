
using Microsoft.IdentityModel.Tokens;
using System.Text;
using GestionDeSeriesAnimadas.API.Middlewares;

namespace GestionDeSeriesAnimadas.API.Servicios
{
    public static class InyeccionDeDependencias
    {
        public static IServiceCollection AddPresentation(this IServiceCollection servicios, IConfiguration configuracion)
        {
            servicios.AddControllers();
            servicios.AddEndpointsApiExplorer();
            servicios.AddSwaggerGen();
            servicios.AddTransient<GlobalExceptionHandlingMiddleware>();


            servicios.AddCors(options =>
            {
                /*
                options.AddPolicy("web", policyBuilder =>
                {
                    policyBuilder.WithOrigins(
                        "http://localhost:4200"
                        );
                    policyBuilder.AllowAnyHeader();
                    policyBuilder.AllowAnyMethod();
                });
                */

                options.AddPolicy("web", policyBuilder =>
                {
                    policyBuilder.AllowAnyOrigin();
                    policyBuilder.AllowAnyHeader();
                    policyBuilder.AllowAnyMethod();
                });

            });

            return servicios;
        }
    }
}
