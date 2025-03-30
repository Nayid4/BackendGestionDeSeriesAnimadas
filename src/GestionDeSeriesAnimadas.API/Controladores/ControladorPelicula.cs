
using Aplicacion.Peliculas.Actualizar;
using Aplicacion.Peliculas.Crear;
using Aplicacion.Peliculas.Eliminar;
using Aplicacion.Peliculas.ListarConFiltros;
using Aplicacion.Peliculas.ListarPorId;
using Aplicacion.Peliculas.ListarTodos;
using Aplicacion.Usuarios.ListarConFiltros;
using GestionDeSeriesAnimadas.API.Controladores;
using Microsoft.AspNetCore.Authorization;

namespace GestionDeSeriesAnimadas.API.Controladores
{
    [Route("pelicula")]
    [Authorize]
    public class ControladorPelicula : ApiController
    {
        private readonly ISender _mediator;

        public ControladorPelicula(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ListarTodos()
        {
            var resultadosDeListarTodos = await _mediator.Send(new ListarTodosLasPeliculasQuery());

            return resultadosDeListarTodos.Match(
                resp => Ok(resp),
                errores => Problem(errores)
            );
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> ListarPorId(Guid id)
        {
            var resultadosDeListarPorId = await _mediator.Send(new ListarPorIdDePeliculaQuery(id));

            return resultadosDeListarPorId.Match(
                resp => Ok(resp),
                errores => Problem(errores)
            );
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Crear([FromBody] CrearPeliculaCommand comando)
        {
            var resultadoDeCrear = await _mediator.Send(comando);

            return resultadoDeCrear.Match(
                resp => Ok(resp),
                errores => Problem(errores)
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            var resultadoDeEliminar = await _mediator.Send(new EliminarPeliculaCommand(id));

            return resultadoDeEliminar.Match(
                resp => NoContent(),
                errores => Problem(errores)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(Guid id, [FromBody] ActualizarPeliculaCommand comando)
        {
            if (comando.Id != id)
            {
                List<Error> errores = new()
                {
                    Error.Validation("Genero.ActualizacionInvalida","El Id de la consulta no es igual al que esta en la solicitud.")
                };

                return Problem(errores);
            }

            var resultadoDeActualizarListaTarea = await _mediator.Send(comando);

            return resultadoDeActualizarListaTarea.Match(
                resp => NoContent(),
                errores => Problem(errores)
            );
        }

        [HttpPost("lista-paginada")]
        public async Task<IActionResult> ListarPorFiltro([FromBody] ListarConFiltrosPeliculaQuery comando)
        {
            var resultadoDeFiltrar = await _mediator.Send(comando);

            return resultadoDeFiltrar.Match(
                resp => Ok(resp),
                errores => Problem(errores)
            );
        }
    }
}
