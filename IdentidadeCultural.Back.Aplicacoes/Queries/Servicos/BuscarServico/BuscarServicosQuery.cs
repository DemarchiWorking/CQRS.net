using IdentidadeCultural.Aplicacoes.Dto;

using IdentidadeCultural.Aplicacoes.Dto;
using IdentidadeCultural.Dominio.Servicos.ObjetosValor;
using IdentidadeCultural.Dominio.Servicos.Resposta;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentidadeCultural.Aplicacoes.Queries.Servicos.BuscarServico
{
		public class BuscarServicosQuery : IRequest<ListaPaginada<ServicoTrabalho>>
		{
			public BuscarServicosQuery(BuscarServicoFiltroDto buscarServicoFiltroDto)
			{
				BuscarServicoFiltroDto = buscarServicoFiltroDto;
			}

			public BuscarServicoFiltroDto BuscarServicoFiltroDto { get; set; }
		}

	}
