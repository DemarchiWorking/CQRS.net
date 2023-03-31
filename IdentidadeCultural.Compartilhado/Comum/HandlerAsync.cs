using AutoMapper;
using Flunt.Notifications;
using IdentidadeCultural.Compartilhado.Aplicacao.Modelos;
using IdentidadeCultural.Compartilhado.Dominio.Entidades;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using AutoMapper;
//using Flunt.Notifications;
//using Microsoft.Extensions.Logging;

namespace IdentidadeCultural.Compartilhado.Aplicacao.Comuns
{


    public interface IHandlerAsync<TRequest, TResponse> where TResponse : class
    {
        Task<TResponse> HandleAsync(TRequest request);
    }

    public interface IHandlerAsync<TRequest>
    {
        Task HandleAsync(TRequest request);
    }

    public interface IHandlerAsyncNoParam<TResponse>
    {
        Task<TResponse> HandleAsync();
    }

    public abstract class HandlerAsync<TRequest, TResponse> : IHandlerAsync<TRequest, TResponse>
        where TResponse : class
    {
        protected ILogger<TRequest> _logger;
        protected IMapper _mapper;
        //private IApplicationUserAccessor? _userAcessor;
        //protected UsuarioLogado _usuario => _userAcessor is null ? new() : _userAcessor.GetUsuario();
        //protected Guid _idUsuario => _usuario.IdUsuario;

        protected HandlerAsync(ILogger<TRequest> logger, IMapper mapper
            //,
            //IApplicationUserAccessor? userAcessor = null
            )
        {
            _logger = logger;
            _mapper = mapper;
            //    _userAcessor = userAcessor;
        }

        public async Task<TResponse?> HandleAsync(TRequest request)
        {
            try
            {
                return await HandleCoreAsync(request);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Não foi possível efetuar a operação {typeof(TRequest)}", request);
                throw;
            }
        }

        protected abstract Task<TResponse?> HandleCoreAsync(TRequest request);
    }


    public abstract class HandlerAsync<TRequest> : IHandlerAsync<TRequest>
    {
        protected ILogger<TRequest> _logger;
        protected IMapper _mapper;
        //private IApplicationUserAccessor? _userAcessor;
        //protected UsuarioLogado _usuario => _userAcessor is null ? new() : _userAcessor.GetUsuario();
        //protected Guid _idUsuario => _usuario.IdUsuario;

        protected HandlerAsync(ILogger<TRequest> logger, IMapper mapper
            //,IApplicationUserAccessor? userAcessor = null
            )
        {
            _logger = logger;
            _mapper = mapper;
            //_userAcessor = userAcessor;
        }

        public async Task HandleAsync(TRequest request)
        {
            try
            {
                await HandleCoreAsync(request);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Não foi possível efetuar a operação {typeof(TRequest)}", request);
                throw;
            }
        }

        public async Task<RespostaApi> CriarResposta<T>(
            int linhasAlteradas,
            string mensagemSucesso,
            string menssagemErro,
            T data,
            IReadOnlyCollection<Notification>? erros = null) where T : Entidade
        {
            if (linhasAlteradas > 0)
            {
                try
                {
                    var vm = _mapper.Map<T>(data);
                    return new RespostaSucesso<T>(mensagemSucesso, vm);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Não foi possível mapear o tipo", data.GetType().Name);
                    return new RespostaErro($"Não foi possível mapear o tipo, {data.GetType().Name}", erros);
                }
            }

            return new RespostaErro(menssagemErro, erros);
        }

        protected abstract Task HandleCoreAsync(TRequest request);
    }

    public abstract class HandlerAsyncNoParam<TResponse> : IHandlerAsyncNoParam<TResponse>
    {
        protected ILogger<bool> _logger;
        protected IMapper _mapper;
        //private IApplicationUserAccessor? _userAcessor;
        //protected UsuarioLogado _usuario => _userAcessor is null ? new() : _userAcessor.GetUsuario();
        //protected Guid _idUsuario => _usuario.IdUsuario;

        protected HandlerAsyncNoParam(IMapper mapper
            //, IApplicationUserAccessor? userAcessor = null
            )
        {
            _mapper = mapper;
            //_userAcessor = userAcessor;
        }

        public async Task<TResponse> HandleAsync()
        {
            try
            {
                return await HandleCoreAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Não foi possível efetuar a operação", false);
                throw;
            }
        }

        public async Task<RespostaApi> CriarResposta<T>(
            int linhasAlteradas,
            string mensagemSucesso,
            string menssagemErro,
            T data,
            IReadOnlyCollection<Notification>? erros = null) where T : Entidade
        {
            if (linhasAlteradas > 0)
            {
                try
                {
                    var vm = _mapper.Map<T>(data);
                    return new RespostaSucesso<T>(mensagemSucesso, vm);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Não foi possível mapear o tipo", data.GetType().Name);
                    return new RespostaErro($"Não foi possível mapear o tipo, {data.GetType().Name}", erros);
                }
            }

            return new RespostaErro(menssagemErro, erros);
        }

        protected abstract Task<TResponse> HandleCoreAsync();
    }
}