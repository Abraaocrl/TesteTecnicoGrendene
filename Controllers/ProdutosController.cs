using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteTecnicoGrendene.Domain.Produtos;
using TesteTecnicoGrendene.Service.Interfaces;

namespace TesteTecnicoGrendene.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    [Authorize]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutosService _produtosService;

        public ProdutosController(IProdutosService produtosService)
        {
            _produtosService = produtosService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> Listar()
        {
            try
            {
                var produtos = await _produtosService.GetProdutos();

                if(produtos == null || produtos.Count() == 0)
                {
                    return NoContent();
                }

                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
