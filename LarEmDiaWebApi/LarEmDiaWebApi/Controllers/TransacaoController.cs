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
            if(!response.EhSucesso)
                return BadRequest(response.Mensagem);

            return Ok(response.Mensagem);
        }
    }
}
