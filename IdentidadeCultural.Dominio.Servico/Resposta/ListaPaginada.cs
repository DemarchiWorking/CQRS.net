using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentidadeCultural.Dominio.Servicos.Resposta { 

    public class ListaPaginada<T>
    {
        public IEnumerable<T>? Registros { get; init; }
        public Paginador Paginador { get; set; }

        public ListaPaginada(IEnumerable<T> registros)
        {
            Registros = registros;
        }
        public ListaPaginada(IEnumerable<T> registros, Paginador paginador)
        {
            Registros = registros;
            Paginador = paginador;
        }
    }

    public class Paginador
    {
        public Paginador(int tamanhoPagina, int paginaAtual, int totalRegistros)
        {
            TamanhoPagina = tamanhoPagina;
            PaginaAtual = paginaAtual;
            TotalRegistros = totalRegistros;
        }

        public int TamanhoPagina { get; private set; }
        public int PaginaAtual { get; private set; }
        public int TotalRegistros { get; private set; }
        public bool TemPaginaAnterior => PaginaAtual > 1;
        public int TotalPaginas => TotalRegistros / TamanhoPagina != 0 ? (TotalRegistros + TamanhoPagina - 1) / TamanhoPagina : 1;
        public bool TemPaginaPosterior => PaginaAtual < TotalPaginas;
    }
}
