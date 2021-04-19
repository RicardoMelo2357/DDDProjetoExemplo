using Dominio.Interfaces.Servicos.Base;
using Infra.Transactions;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.DDDProjetoExemplo.Controllers.Base
{
    public class ControllerBase<TRequest, TResponse> : ApiController where TRequest : class where TResponse : class
    {
        private IServicoBase<TRequest, TResponse> _servicoBase;
        private readonly IUnitOfWork _unityOfWork;

        public ControllerBase() { }
        public ControllerBase(IUnitOfWork unityOfWork) { _unityOfWork = unityOfWork; }

        public HttpResponseMessage Response<T>(T result, IServicoBase<TRequest, TResponse> servicoBase)
        {
            _servicoBase = servicoBase;

            if (servicoBase.Notifications.Any())
                return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(servicoBase.Notifications, Formatting.Indented));

            try
            {
                //_unityOfWork.Commit();
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        protected HttpResponseMessage Response(IServicoBase<TRequest, TResponse> servicoBase)
        {
            _servicoBase = servicoBase;

            if (servicoBase.Notifications.Any())
                return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(servicoBase.Notifications, Formatting.Indented));

            try
            {
                //_unityOfWork.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        protected HttpResponseMessage ResponseException(Exception ex) => Request.CreateResponse(HttpStatusCode.InternalServerError, new { errors = ex.Message, exception = ex.ToString() });

        protected override void Dispose(bool disposing)
        {
            //Realiza o dispose no serviço para que possa ser zerada as notificações
            if (_servicoBase != null)
            {
                _servicoBase.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}