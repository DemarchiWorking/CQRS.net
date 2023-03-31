using IdentidadeCultural.Compartilhado.Dominio.Extensoes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Two.Api.Models;

namespace IdentidadeCultural.Api.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        protected object ListarEnum<T>() where T : Enum
        {
            return EnumExtensoes
                .ObterDescricoes<T>()
                .Select(descricao
                    => new ListaEnum(descricao, EnumExtensoes.ObterEnumPorDescription<T>(descricao).ToString())
                );
        }
    }
}