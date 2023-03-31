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


namespace IdentidadeCultural.Aplicacao.Servico.Commands
{
    {
        [Injection(Di.Scoped)]
        public class AdicionarParaAlteracaoCommandHandler : HandlerAsync<AdicionarParaAlteracaoCommand, RespostaApi>
        {
            //private readonly IFaturamentoContext _context;
            //private readonly ICompartilhadoContext _contextCompartilhado;

            public AdicionarParaAlteracaoCommandHandler(
                ILogger<AdicionarParaAlteracaoCommand> logger,
                IMapper mapper
                //, IFaturamentoContext context,
                //ICompartilhadoContext contextCompartilhado,
                //IApplicationUserAccessor? userAcessor = null
                ) : base(logger, mapper
                    //, userAcessor
                    )
            {
                //_context = context;
                //_contextCompartilhado = contextCompartilhado;
            }

            protected override async Task<RespostaApi?> HandleCoreAsync(AdicionarParaAlteracaoCommand request)
            {

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

                return CriarResposta(response);
            }

            private RespostaApi CriarResposta(int response)
            {
                if (response > 0)
                {
                    return new RespostaSucesso<ItemSolicitacaoFaturamentoExclusaoVm>("Solicitação de faturamento adicionada para exclusão com sucesso!", null);
                }
                return new RespostaErro("Não foi possível adicionar para exclusão", null);
            }
        }
    }
