using IdentidadeCultural.Aplicacao.Servico.Commands;
using IdentidadeCultural.Compartilhado.Aplicacao.Comuns;
using IdentidadeCultural.Compartilhado.Aplicacao.Modelos;
using IdentidadeCultural.DominioServicos.ObjetosValor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Swagger;

namespace IdentidadeCultural.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : MainController
    {
    }

    /// <summary>
    /// Cancela a solicitação de alteracao faturamento a partir do id.
    /// </summary>
    /// <returns>Retorna ItemSolicitacaoFaturamentoAlteracaoVm com status atualizado</returns>
    /// <response code="200">Solicitação cancelada com sucesso. E o status passa a ser aguardando.</response>
    /// <response code="422">Erro ao cancelar a solicitação de alteracao.</response>
    /// <response code="204">Solicitação não existe para o id passado.</response>
    [HttpPut("adicionar/sem-usuario")]//, Authorize(Policy = "Servicos")
    [ProducesResponseType(typeof(RespostaSucesso<Servico>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(RespostaErro), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(RespostaErro), StatusCodes.Status204NoContent)]
    public async Task<ActionResult> CriarServicoSemUsuario(
        [FromServices] IHandlerAsync<AdicionarParaAlteracaoCommand, RespostaApi> handler,
        [FromBody] AdicionarParaAlteracaoCommand criarServicoCommand
        )
    {
        var response = await handler.HandleAsync(criarServicoCommand);
        if (response.Success)
        {
            return Ok(response);
        }

        var errorResponse = response as RespostaErroComStatus;

        if (errorResponse!.StatusCode == StatusCodes.Status204NoContent)
        {
            return NoContent();
        }
        if (errorResponse!.StatusCode == StatusCodes.Status422UnprocessableEntity)
        {
            return UnprocessableEntity(errorResponse);
        }
        else
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// Retorna a lista paginada de solicitações de faturamento e seus filtros
    /// </summary>
    /*
    [HttpGet, Authorize(Policy = "FaturamentoSolicitador")]
    [ProducesResponseType(typeof(ListaPaginada<SolicitacaoFaturamentoVm>), StatusCodes.Status200OK)]
    public async Task<ActionResult> Faturamento(
        [FromServices] IHandlerAsync<BuscarSolicitacoesFaturamentoQuery, ListaPaginada<SolicitacaoFaturamentoVm>> handler,
        [FromQuery] StatusAtividadeUpeFiltroDto query)
    {
        var buscarDetalhesPedidoQuery = new BuscarSolicitacoesFaturamentoQuery(query);
        return Ok(await handler.HandleAsync(buscarDetalhesPedidoQuery));
    }
    */
}
