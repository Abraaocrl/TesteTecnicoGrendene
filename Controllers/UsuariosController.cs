using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteTecnicoGrendene.Domain.Usuarios;
using TesteTecnicoGrendene.Helpers;
using TesteTecnicoGrendene.Repository.Interfaces;
using TesteTecnicoGrendene.Service;
using TesteTecnicoGrendene.Service.Interfaces;

namespace TesteTecnicoGrendene.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioService usuariosService;

        public UsuariosController(IUsuarioService usuariosRepository)
        {
            this.usuariosService = usuariosRepository;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> Login(string email, string senha)
        {
            try
            {
                var token = await usuariosService.Login(email, senha);

                if(token == null)
                {
                    return Unauthorized();
                }

                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("cadastrar")]
        [AllowAnonymous]
        public async Task<ActionResult<Usuario>> Cadastrar(string email, string nome, string senha)
        {
            try
            {
                var usuario = await usuariosService.Cadastrar(email, nome, senha);

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("poremail")]
        [Authorize]
        public async Task<ActionResult<Usuario>> PorEmail(string email)
        {
            try
            {
                var usuario = await usuariosService.GetByEmail(email);

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Remover(int id)
        {
            try
            {
                var remocao = await usuariosService.Remover(id);

                if (!remocao)
                {
                    return BadRequest();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
