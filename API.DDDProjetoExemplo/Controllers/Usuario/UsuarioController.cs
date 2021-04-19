using API.DDDProjetoExemplo.Controllers.Base;
using Dominio.Argumentos.Usuario;
using Dominio.Interfaces.Servicos.Usuario;
using System;
using System.Net.Http;
using System.Web.Http;

namespace API.DDDProjetoExemplo.Controllers.Usuario
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IServicoUsuario _servicoUsuario;
        public UsuarioController(IServicoUsuario servicoUsuario)
        {
            _servicoUsuario = servicoUsuario;
        }

        [HttpGet, Route("selecionar/{id}")]
        public HttpResponseMessage Selecionar(int id)
        {
            try
            {
                var response = _servicoUsuario.Selecionar(id);
                return Response(response, _servicoUsuario);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }

        [HttpPost, Route("adicionar")]
        public HttpResponseMessage Adicionar(UsuarioRequest request)
        {
            try
            {
                var response = _servicoUsuario.Adicionar(request);
                return Response(response, _servicoUsuario);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }

        [HttpPut, Route("alterar")]
        public HttpResponseMessage Alterar(UsuarioRequest request)
        {
            try
            {
                var response = _servicoUsuario.Alterar(request);
                return Response(response, _servicoUsuario);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }

        [HttpGet, Route("listar")]
        public HttpResponseMessage Listar()
        {
            try
            {
                var response = _servicoUsuario.Listar();
                return Response(response, _servicoUsuario);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }

        [HttpGet, Route("listarAtivos")]
        public HttpResponseMessage ListarAtivos()
        {
            try
            {
                var response = _servicoUsuario.ListarAtivos();
                return Response(response, _servicoUsuario);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }
    }
}