using IdentidadeCultural.Aplicacoes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentidadeCultural.Aplicacoes.Queries.Servicos.BuscarServico
{
		public class BuscarServicosQuery
		{
			public BuscarServicosQuery(BuscarServicoFiltroDto buscarServicoFiltroDto)
			{
				BuscarServicoFiltroDto = buscarServicoFiltroDto;
			}

			public BuscarServicoFiltroDto BuscarServicoFiltroDto { get; set; }
		}

	}
