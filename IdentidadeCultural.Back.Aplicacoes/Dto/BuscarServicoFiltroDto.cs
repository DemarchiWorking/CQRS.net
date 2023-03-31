using IdentidadeCultural.DominioServicos.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentidadeCultural.Aplicacoes.Dto
{
    public class BuscarServicoFiltroDto
    {
        [Required]
        public int Pagina { get; set; }

        [Required]
        public int TamanhoPagina { get; set; }

        public Categoria Categoria { get; set; }

        public string Titulo { get; set; }
    }
}
