using IdentidadeCultural.Dominio.Servicos.ObjetosValor;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentidadeCultural.Aplicacao.Servico.Commands
{
    public class AdicionarServicoCommand :  IRequest<ServicoTrabalho>
    {
        
        public string Titulo { get; set; }
        
    }
    

}
