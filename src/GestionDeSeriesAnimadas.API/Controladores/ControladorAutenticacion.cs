using Aplicacion.Usuarios.DatosUsuario;
using Aplicacion.Usuarios.IniciarSesion;
using Aplicacion.Usuarios.RefrescarToken;
using GestionDeSeriesAnimadas.API.Controladores;
using Microsoft.AspNetCore.Authorization;

namespace GestionDeSeriesAnimadas.API.Controladores
{
    [Route("autenticacion")]
    [Authorize]
    public class ControladorAutenticacion : ApiController
    {
        private readonly ISender _mediator;

        public ControladorAutenticacion(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("iniciar-sesion")]
        [AllowAnonymous]
        public async Task<IActionResult> IniciarSesion([FromBody] IniciarSesionQuery comando)
        {
            var resultadoDeIniciarSesion = await _mediator.Send(comando);

            return resultadoDeIniciarSesion.Match(
                auth => Ok(auth),
                errores => Problem(errores)
            );
        }

        [HttpGet("refrescar-token")]
        public async Task<IActionResult> RefescarToken()
        {
            var resultado = await _mediator.Send(new RefrescarTokenQuery());

            return resultado.Match(
                auth => Ok(auth),
                errores => Problem(errores)
            );
        }

        [HttpGet("datos-usuario")]
        public async Task<IActionResult> ListarDatosUsuario()
        {
            var resultadoDeListarDatosUsuario = await _mediator.Send(new DatosUsuarioQuery());

            return resultadoDeListarDatosUsuario.Match(
                usuarioid => Ok(usuarioid),
                errores => Problem(errores)
            );
        }
    }
}
