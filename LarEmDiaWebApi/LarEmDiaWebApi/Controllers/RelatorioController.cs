using LarEmDia.Application.Relatorios;
using LarEmDia.Application.Relatorios.ListaPessoasTotais;
using LarEmDia.Application.Relatorios.PessoasTotalSumario;
using LarEmDia.Domain.Abstractions;
using LarEmDia.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LarEmDiaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RelatorioController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult<PagedResult<PessoaTotaisDto>>> ListaPessoasTotais(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var pagination = new PaginationParameters() { PageNumber = pageNumber, PageSize = pageSize };
            var query = new ListarPessoasTotaisRequest(pagination);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<TotaisDto>> PessoasTotalSumario()
        {
            var query = new PessoasTotalSumarioRequest();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
