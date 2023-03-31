using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flunt.Notifications;


namespace IdentidadeCultural.Compartilhado.Aplicacao.Modelos
{

    public abstract class RespostaApi
    {
        public bool Success { get; init; }
        public string Message { get; init; }

        protected RespostaApi(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }

    public class RespostaSucesso<T> : RespostaApi where T : class
    {
        public T? Data { get; init; }
        public RespostaSucesso(string message, T? data) : base(true, message)
            => Data = data;
    }

    public class RespostaErro : RespostaApi
    {
        public IEnumerable<Notification>? Erros { get; set; }
        public RespostaErro(string message, IEnumerable<Notification>? erros = null) : base(false, message)
            => Erros = erros;
    }

    public class RespostaErroComStatus : RespostaErro
    {
        public int StatusCode { get; set; }
        public RespostaErroComStatus(string message, IEnumerable<Notification>? erros = null, int statusCode = 0) : base(message, erros)
        {
            StatusCode = statusCode;
        }
    }
}