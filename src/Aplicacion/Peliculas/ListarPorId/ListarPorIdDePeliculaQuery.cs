using Aplicacion.Peliculas.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Peliculas.ListarPorId
{
    public record ListarPorIdDePeliculaQuery(Guid Id) : IRequest<ErrorOr<RespuestaPelicula>>;
}
