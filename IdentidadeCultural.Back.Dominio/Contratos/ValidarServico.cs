using Flunt.Validations;
using IdentidadeCultural.DominioServicos.Enum;
using IdentidadeCultural.DominioServicos.ObjetosValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentidadeCultural.DominioServicos.Contratos
{
    public class ValidarServico : Contract<Servico>
    {
        public ValidarServico(Servico servico, Categoria categoria)=>
            Requires()
            .IsTrue((servico.Categoria != Categoria.Administrador) 
                && (servico.Categoria != Categoria.Administrador),
                nameof(Servico.Categoria),
                $"Para adicionar um Administrador você precisa de permissao.");
                
                // Só pode se as condicao for verdadeiras
            //.IsTrue()...

    }
}
