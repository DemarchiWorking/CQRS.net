using AutoMapper;
using IdentidadeCultural.Compartilhado.Aplicacao.Atributos;
using IdentidadeCultural.Compartilhado.Aplicacao.Comuns;
using IdentidadeCultural.Compartilhado.Aplicacao.Modelos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentidadeCultural.Dominio.Servicos;
using IdentidadeCultural.Dominio.Servicos.ObjetosValor;
using MediatR;
using IdentidadeCultural.Dominio.Servicos.Enum;

namespace IdentidadeCultural.Aplicacao.Servico.Commands
{
        //    [Injection(Di.Scoped)]
        public class AdicionarServicoCommandHandler : IRequestHandler<AdicionarServicoCommand, ServicoTrabalho>//: HandlerAsync<AdicionarParaAlteracaoCommand, RespostaApi>
        {

        public AdicionarServicoCommandHandler(IMediator mediator)
        {
            this._mediator = mediator;

        }
        //private readonly IFaturamentoContext _context;
        //private readonly ICompartilhadoContext _contextCompartilhado;
        private readonly IMediator _mediator;

        public AdicionarServicoCommandHandler(
                ILogger<AdicionarServicoCommand> logger,
                IMapper mapper
                //, IFaturamentoContext context,
                //ICompartilhadoContext contextCompartilhado,
                //IApplicationUserAccessor? userAcessor = null
                ) : base(
                //logger, mapper, userAcessor
                )
        {
            //_context = context;
            //_contextCompartilhado = contextCompartilhado;
            //this._mediator = mediator;
        }

        
		
        //protected override async Task<RespostaApi?> HandleCoreAsync(AdicionarServicoCommand request)
        public Task<ServicoTrabalho> Handle(AdicionarServicoCommand request, CancellationToken cancellationToken)
        {
            ServicoTrabalho Audiovisual = new ServicoTrabalho(new Guid(), null, "Audiovisual",
            Categoria.Audiovisual, "Audiovisual", "",
            DateTime.Now
            );

            return Task.FromResult(Audiovisual);
            //return Task.FromResult(Unit.Value);
            /*
                var solicitacao = _context.SolicitacaoFaturamentos.FirstOrDefault(s => s.Id == request.solicitacaoId);

                if (solicitacao is null)
                {
                    return new RespostaErro("Solicitação de faturamento inexistente.");
                }

                if (!solicitacao.PodePuxarAlteracao)
                {
                    return new RespostaErro(
                        $"A solicitação só pode ser puxada se o status for : {StatusSolicitacao.Alterado} , {StatusSolicitacao.Liberado} ou {StatusSolicitacao.Bloqueado}");
                }

                solicitacao.AdicionarParaExclusao();

                _context.SolicitacaoFaturamentos.Update(solicitacao);

                _contextCompartilhado.Historicos.Add(new Historico(solicitacao.Id, "TWO_FATURAMENTO_SOLICITACAO", "FATURAMENTO", "UPDATE",
                        DateTime.Now, JsonSerializer.Serialize(solicitacao), _idUsuario));


                var response = await _context.SaveChangesAsync();

                if (response > 0)
                {
                    await _context.SaveChangesAsync();
                }
                */
            //return null;
        }

        /*
                private RespostaApi CriarResposta(int response)
                {
                    if (response > 0)
                    {
                        return new RespostaSucesso<ServicoTrabalho>("Solicitação de faturamento adicionada para exclusão com sucesso!", null);
                    }
                    return new RespostaErro("Não foi possível adicionar para exclusão", null);
                }
            }
        */
    }
}
