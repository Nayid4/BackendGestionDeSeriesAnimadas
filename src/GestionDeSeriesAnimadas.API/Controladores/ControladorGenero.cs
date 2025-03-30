
using Aplicacion.Generos.Actualizar;
using Aplicacion.Generos.Crear;
using Aplicacion.Generos.Eliminar;
using Aplicacion.Generos.ListarConFiltros;
using Aplicacion.Generos.ListarPorId;
using Aplicacion.Generos.ListarTodos;
using Microsoft.AspNetCore.Authorization;

namespace GestionDeSeriesAnimadas.API.Controladores

{
    [Route("genero")]
    [Authorize]
    public class ControladorGenero : ApiController
    {
        private readonly ISender _mediator;

        public ControladorGenero(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            var resultadosDeListarTodos = await _mediator.Send(new ListarTodosLosGenerosQuery());

            return resultadosDeListarTodos.Match(
                resp => Ok(resp),
                errores => Problem(errores)
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarPorId(Guid id)
        {
            var resultadosDeListarPorId = await _mediator.Send(new ListarPorIdDeGeneroQuery(id));

            return resultadosDeListarPorId.Match(
                resp => Ok(resp),
                errores => Problem(errores)
            );
        }


        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearGeneroCommand comando)
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
            var resultadoDeEliminar = await _mediator.Send(new EliminarGeneroCommand(id));

            return resultadoDeEliminar.Match(
                resp => NoContent(),
                errores => Problem(errores)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(Guid id, [FromBody] ActualizarGeneroCommand comando)
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
        public async Task<IActionResult> ListarPorFiltro([FromBody] ListarConFiltrosGeneroQuery comando)
        {
            var resultadoDeFiltrar = await _mediator.Send(comando);

            return resultadoDeFiltrar.Match(
                resp => Ok(resp),
                errores => Problem(errores)
            );
        }
    }
}
