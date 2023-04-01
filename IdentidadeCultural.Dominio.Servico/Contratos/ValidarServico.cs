using Flunt.Validations;
using IdentidadeCultural.Dominio.Servicos.Enum;
using IdentidadeCultural.Dominio.Servicos.ObjetosValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentidadeCultural.Dominio.Servicos.Contratos
{
    public class ValidarServico : Contract<ServicoTrabalho>
    {
        public ValidarServico(ServicoTrabalho servico, Categoria categoria)=>
            Requires()
            .IsTrue((servico.Categoria != Categoria.Administrador) 
                && (servico.Categoria != Categoria.Administrador),
                nameof(ServicoTrabalho.Categoria),
                $"Para adicionar um Administrador você precisa de permissao.");
                
                // Só pode se as condicao for verdadeiras
            //.IsTrue()...

    }
}
