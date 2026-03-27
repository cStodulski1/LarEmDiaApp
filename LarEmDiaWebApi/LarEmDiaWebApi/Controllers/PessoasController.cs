using LarEmDia.Application.Pessoas.AtualizarPessoa;
using LarEmDia.Application.Pessoas.BuscarPessoaPorId;
using LarEmDia.Application.Pessoas.CadastrarPessoa;
using LarEmDia.Application.Pessoas.ExcluirPessoa;
using LarEmDia.Application.Pessoas.ListarPessoas;
using LarEmDia.Domain.Abstractions;
using LarEmDia.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LarEmDiaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PessoasController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> CadastrarAsync([FromBody] CadastrarPessoaRequest command)
        {
            var result = await _mediator.Send(command);
            return Ok(result.Mensagem);
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<PessoaDto>>> ListarAsync(
            [FromQuery] string busca = "",
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var pagination = new PaginationParameters() { PageNumber = pageNumber, PageSize = pageSize};
            var query = new ListarPessoasRequest(busca, pagination);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorIdAsync(Guid id)
        {
            var query = new BuscarPessoaPorIdRequest(id);
            var result = await _mediator.Send(query);
            if(!result.EhSucesso)
            {
                return BadRequest(result.Mensagem);
            }
            return Ok(result.Data);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> AtualizarAsync([FromRoute]Guid id,  [FromBody] AtualizarPessoaRequest command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);

            if(!result.EhSucesso)
            {
                return BadRequest(result.Mensagem);
            }

            return Ok(result.Mensagem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirAsync(Guid id)
        {
            var command = new ExcluirPessoaRequest(id);
            var result = await _mediator.Send(command);
            return Ok(result.Mensagem);
        }
    }
}