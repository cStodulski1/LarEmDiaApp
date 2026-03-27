using LarEmDia.Application.Categorias.CadastrarCategoria;
using LarEmDia.Application.Categorias.ListarCategoria;
using LarEmDia.Domain.Abstractions;
using LarEmDia.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LarEmDiaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoriasController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] CadastrarCategoriaRequest command)
        {
            var result = await _mediator.Send(command);
            return Ok(result.Mensagem);
        }

        [HttpGet]
        public async Task<IActionResult> Listar(
            [FromQuery] string busca = "",
            [FromQuery] string finalidade = "Ambas",
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var pagination = new PaginationParameters() { PageNumber = pageNumber, PageSize = pageSize };
            var finalidadeEnum = Enum.TryParse<FinalidadeEnum>(finalidade, true, out var parsedFinalidade) ? parsedFinalidade : FinalidadeEnum.Despesa;
            var query = new ListarCategoriaRequest(busca, finalidadeEnum, pagination);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
