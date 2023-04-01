using IdentidadeCultural.Aplicacao.Servico.Commands;
using IdentidadeCultural.Aplicacoes.Dto;
using IdentidadeCultural.Aplicacoes.Queries.Servicos.BuscarServico;
using IdentidadeCultural.Compartilhado.Aplicacao.Comuns;
using IdentidadeCultural.Compartilhado.Aplicacao.Modelos;
using IdentidadeCultural.Dominio.Servicos.ObjetosValor;
using IdentidadeCultural.Dominio.Servicos.Resposta;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore;

namespace IdentidadeCultural.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : MainController
        {
        private readonly IMediator _mediator;

        public ServicoController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Retorna ItemSolicitacaoFaturamentoAlteracaoVm com status atualizado</returns>
        /// <response code="200">Servico adicionado com sucesso.</response>
        /// <response code="422">Erro ao tentar adicionar serviço.</response>
        /// <response code="204">Solicitação não existe para o id passado.</response>
        [HttpPut("adicionar/sem-usuario")]//, Authorize(Policy = "Servicos")
        [ProducesResponseType(typeof(RespostaSucesso<ServicoTrabalho>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RespostaErro), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(RespostaErro), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CriarServico(
        //    [FromServices] IHandlerAsync<AdicionarServicoCommand, RespostaApi> handler,
            [FromBody] AdicionarServicoCommand criarServicoCommand
            )
        {
            //var response = await handler.HandleAsync(criarServicoCommand);
            //var response = "t";
            var response = await _mediator.Send(criarServicoCommand);
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return null;
            }

            /*
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
            } */
        }

        /// <summary>
        /// Retorna a lista paginada de solicitações de faturamento e seus filtros
        /// </summary>
        
        [HttpGet]//Authorize(Policy = "FaturamentoSolicitador")
        [ProducesResponseType(typeof(ListaPaginada<ServicoTrabalho>), StatusCodes.Status200OK)]
        public async Task<ActionResult> Faturamento(//[FromServices] BuscarServicosQuery buscarServicosQuery,
        //    [FromServices] IHandlerAsync<BuscarServicosQuery, ListaPaginada<ServicoTrabalho>> handler,
            [FromQuery] BuscarServicoFiltroDto query)
        {
            var buscarDetalhesPedidoQuery = new BuscarServicosQuery(query);
            var resultado = await _mediator.Send(buscarDetalhesPedidoQuery);
            return Ok(resultado);
            //return Ok(await handler.HandleAsync(buscarDetalhesPedidoQuery));
        }
        
    }


}
