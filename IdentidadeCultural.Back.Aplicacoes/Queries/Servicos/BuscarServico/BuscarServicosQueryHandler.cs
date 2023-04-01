using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using IdentidadeCultural.Compartilhado.Aplicacao.Comuns;
using IdentidadeCultural.Compartilhado.Aplicacao.Atributos;
using Microsoft.Extensions.Logging;
using AutoMapper;
using IdentidadeCultural.Dominio.Servicos.Enum;
using IdentidadeCultural.Dominio.Servicos.ObjetosValor;
using IdentidadeCultural.Dominio.Servicos.Resposta;
using MediatR;

namespace IdentidadeCultural.Aplicacoes.Queries.Servicos.BuscarServico
{

	

	[Injection(Di.Scoped)]

	public class BuscarServicosQueryHandler : IRequestHandler<BuscarServicosQuery,ListaPaginada<ServicoTrabalho>>// : HandlerAsync<BuscarServicosQuery, ListaPaginada<ServicoTrabalho>>
	{
		//private readonly IFaturamentoContext _context;
		private readonly IMediator _mediator;

		public BuscarServicosQueryHandler(IMediator mediator)
		{
			this._mediator = mediator;

		}

		public BuscarServicosQueryHandler(ILogger<BuscarServicosQuery> logger, IMapper mapper
			//, IServicoContext context, IApplicationUserAccessor userAcessor
			) : 
			base(
			//logger, mapper, userAcessor
			)
		{

			//_context = context;
		}

		public Task<ListaPaginada<ServicoTrabalho>> Handle(BuscarServicosQuery request, CancellationToken cancellationToken)
		//protected override async Task<ListaPaginada<ServicoTrabalho>?> HandleCoreAsync(BuscarServicosQuery request)
		{
			ServicoTrabalho Audiovisual = new ServicoTrabalho(new Guid(), null, "Audiovisual",
				Categoria.Audiovisual, "Audiovisual", "",
				DateTime.Now
				);

			ServicoTrabalho Musico = new ServicoTrabalho(new Guid(), null, "Músico",
				Categoria.Musico, "Músico", "",
				DateTime.Now
				);


			List<ServicoTrabalho> lista = new List<ServicoTrabalho>();
			lista.Add(Audiovisual);
			lista.Add(Musico);

			var listaPaginadaResposta = new ListaPaginada<ServicoTrabalho>(lista);

			return Task.FromResult(listaPaginadaResposta);

		}

		/* var solicitacoes = _context.SolicitacaoFaturamentos.AsNoTracking();//.Where(x => x.UsuarioId == _idUsuario);

		solicitacoes = GetOrder(request.StatusAtividadeUpeFiltroDto, solicitacoes);

		if (!string.IsNullOrEmpty(request.StatusAtividadeUpeFiltroDto.Pesquisa))
		{
			solicitacoes = GetPesquisa(request.StatusAtividadeUpeFiltroDto, solicitacoes);
		}
		if (request.StatusAtividadeUpeFiltroDto.Filtro != null)
		{
			solicitacoes = GetStatus(request.StatusAtividadeUpeFiltroDto, solicitacoes);
		}

		var querySolicitacaoList = await solicitacoes
			.Where(solicitacao => solicitacao.StatusSolicitacao != StatusSolicitacao.SemValor)
			.Include(x => x.DemandaAtividade)
			.ThenInclude(x => x.Atividade)
			.Include(x => x.DemandaAtividade)
			.ThenInclude(x => x.Fornecedor)
			.Include(x => x.Agencia)
			.Skip((request.StatusAtividadeUpeFiltroDto.Pagina - 1) * request.StatusAtividadeUpeFiltroDto.TamanhoPagina)
			.Take(request.StatusAtividadeUpeFiltroDto.TamanhoPagina)
			.Select(p => new SolicitacaoFaturamentoVm()
			{
				SolicitacaoId = p.Id,
				Upe = p.DemandaAtividade.Demanda.CodigoUPE,
				StatusSolicitacao = p.StatusSolicitacao.ToString(),
				Agencia = new AgenciaVm(p.Agencia),
				Area = p.Area,
				Atividade = p.DemandaAtividade.Atividade.NomeAtividade,
				Fornecedor = p.DemandaAtividade.Fornecedor,
				PodeCriarPedido = p.StatusSolicitacao == StatusSolicitacao.Liberado ? true : false,
				PodeReprocessarPedido = p.StatusSolicitacao == StatusSolicitacao.Erro ? true : false,
				PodeSelecionarSolicitacao = p.StatusSolicitacao == StatusSolicitacao.Erro || p.StatusSolicitacao == StatusSolicitacao.Liberado ? true : false,
				PodePuxarExclusao = p.PodePuxarExclusao,
				PodeExcluir = p.PodeExcluir,
				PodeCancelarExclusao = p.PodeCancelarExclusao,
				PodeReprocessarExclusao = p.PodeReprocessarExclusao,
				PodeSelecionarExclusao = p.PodeSelecionarExclusao,
				Valor = p.Valor
			})
					.ToListAsync();

		var solicitacaoCount = await solicitacoes.CountAsync();

		var listaPaginada = new ListaPaginada<SolicitacaoFaturamentoVm>(querySolicitacaoList, new Paginador(request.StatusAtividadeUpeFiltroDto.TamanhoPagina, request.StatusAtividadeUpeFiltroDto.Pagina, solicitacaoCount));

		return listaPaginada;
	}

	private static IQueryable<SolicitacaoFaturamento> GetOrder(StatusAtividadeUpeFiltroDto statusAtividadeUpeFiltroDto, IQueryable<SolicitacaoFaturamento> query)
	{
		if (statusAtividadeUpeFiltroDto.Coluna == FiltroColunaSolicitarFaturamento.Upe)
		{
			query = statusAtividadeUpeFiltroDto.Ordem == true ?
			query.OrderBy(x => x.DemandaAtividade.Demanda.CodigoUPE) : query = query.OrderByDescending(x => x.DemandaAtividade.Demanda.CodigoUPE);

		}

		if (statusAtividadeUpeFiltroDto.Coluna == FiltroColunaSolicitarFaturamento.Agencia)
		{
			query = statusAtividadeUpeFiltroDto.Ordem == true ?
			query.OrderBy(x => x.Agencia.Numero) : query = query.OrderByDescending(x => x.Agencia.Numero);
		}

		if (statusAtividadeUpeFiltroDto.Coluna == FiltroColunaSolicitarFaturamento.Area)
		{
			query = statusAtividadeUpeFiltroDto.Ordem == true ?
			query.OrderBy(x => x.Area) : query = query.OrderByDescending(x => x.Area);
		}

		if (statusAtividadeUpeFiltroDto.Coluna == FiltroColunaSolicitarFaturamento.Atividade)
		{
			query = statusAtividadeUpeFiltroDto.Ordem == true ?
			query.OrderBy(x => x.DemandaAtividade.Atividade.NomeAtividade) : query = query.OrderByDescending(x => x.DemandaAtividade.Atividade.NomeAtividade);
		}

		if (statusAtividadeUpeFiltroDto.Coluna == FiltroColunaSolicitarFaturamento.Fornecedor)
		{
			query = statusAtividadeUpeFiltroDto.Ordem == true ?
			query.OrderBy(x => x.DemandaAtividade.Atividade.Fornecedor.RazaoSocial) : query = query.OrderByDescending(x => x.DemandaAtividade.Atividade.Fornecedor.RazaoSocial);
		}

		if (statusAtividadeUpeFiltroDto.Coluna == FiltroColunaSolicitarFaturamento.Valor)
		{
			query = statusAtividadeUpeFiltroDto.Ordem == true ?
			query.OrderBy(x => x.Valor) : query = query.OrderByDescending(x => x.Valor);
		}

		return query;
	}

	private static IQueryable<SolicitacaoFaturamento> GetPesquisa(StatusAtividadeUpeFiltroDto statusAtividadeUpeFiltroDto, IQueryable<SolicitacaoFaturamento> query)
	{
		if (Regex.IsMatch(statusAtividadeUpeFiltroDto.Pesquisa, @"^\d+$"))
		{
			var PesquisaToInt = int.Parse(statusAtividadeUpeFiltroDto.Pesquisa);
			query = query.Where(x => x.Agencia.Numero == PesquisaToInt ||
			x.DemandaAtividade.Demanda.CodigoUPE == PesquisaToInt);
			return query;
		}

		query = query.Where(x => x.DemandaAtividade.Atividade.NomeAtividade.Contains(statusAtividadeUpeFiltroDto.Pesquisa) ||
		x.DemandaAtividade.Atividade.Fornecedor.RazaoSocial.Contains(statusAtividadeUpeFiltroDto.Pesquisa));
		return query;
	}

	private static IQueryable<SolicitacaoFaturamento> GetStatus(StatusAtividadeUpeFiltroDto statusAtividadeUpeFiltroDto, IQueryable<SolicitacaoFaturamento> query)
	{
		query = query.Where(x => x.StatusSolicitacao == Enum.Parse<StatusSolicitacao>(statusAtividadeUpeFiltroDto.Filtro));
		return query;
		*/
	}


}