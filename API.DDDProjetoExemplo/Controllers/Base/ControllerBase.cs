using Dominio.Interfaces.Servicos.Base;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.DDDProjetoExemplo.Controllers.Base
{
    public class ControllerBase : ApiController 
    {
        private IServicoBase _servicoBase;

        public ControllerBase() { }

        public HttpResponseMessage Response(object result, IServicoBase servicoBase)
        {
            _servicoBase = servicoBase;

            if (servicoBase.Notifications.Any())
                return Request.CreateResponse(HttpStatusCode.OK, servicoBase.Notifications);

            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        public HttpResponseMessage ResponseException(Exception ex) => Request.CreateResponse(HttpStatusCode.InternalServerError, new { errors = ex.Message, exception = ex.ToString() });

        protected override void Dispose(bool disposing)
        {
            if (_servicoBase != null)
                _servicoBase.Dispose();

            base.Dispose(disposing);
        }
    }
}