using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IdentidadeCultural.Compartilhado.Dominio.Logging
{


    public class LogSplunk
    {
        [JsonProperty("timestamp")]
        public long Timestamp { get; init; }

        [JsonProperty("sigla_automacao")]
        public string SiglaAutomacao => "TB3";

        [JsonProperty("usuario")]
        public string Usuario { get; init; } = null!;

        [JsonProperty("aplicacao")]
        public string Aplicacao => "Two";

        [JsonProperty("origem")]
        public string Origem => "IIS";

        [JsonProperty("hostname_origem")]
        public string HostnameOrigem => "SCWTD0180CLDN";

        [JsonProperty("ip_origem")]
        public string? IPOrigem { get; set; } = null!;

        [JsonProperty("destino")]
        public string Destino => "";

        [JsonProperty("acao")]
        public string Acao { get; set; } = null!; //GET, POST

        [JsonProperty("tecnologia")]
        public string Tecnologia => ".NET CORE";

        [JsonProperty("versao")]
        public string? Versao { get; set; } = null!;

        [JsonProperty("status")]
        public string Status { get; set; } = null!;

        [JsonProperty("cod_retorno")]
        public int CodRetorno { get; set; }

        [JsonProperty("desc_retorno")]
        public string DescRetorno { get; set; } = null!;

        [JsonProperty("inicio")]
        public string Inicio => DateTime.Now.ToString();

        [JsonProperty("fim")]
        public string Fim => DateTime.Now.ToString();

        [JsonProperty("Persistencia_da_Informacao")]
        public string PersistenciaDaInformacao => "Nao";

        [JsonProperty("Method_API")]
        public string MethodApi { get; set; } = null!;

        [JsonProperty("Endpoint_API")]
        public string EndpointApi { get; set; } = null!;

        private long UnixDatetime() => (long)DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        public LogSplunk() => Timestamp = UnixDatetime();
    }

}