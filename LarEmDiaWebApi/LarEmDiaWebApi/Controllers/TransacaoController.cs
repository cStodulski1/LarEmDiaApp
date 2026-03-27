using LarEmDia.Application.Transacoes.CadastrarTransacao;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LarEmDiaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TransacaoController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] CadastrarTransacaoRequest command)
        {
            var response = await _mediator.Send(command);
            return Ok(response.Mensagem);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            return Ok("Listar transações - funcionalidade a ser implementada");
        }
    }
}
