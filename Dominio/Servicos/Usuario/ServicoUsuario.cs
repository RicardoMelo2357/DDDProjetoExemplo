using AutoMapper;
using Dominio.Argumentos.Usuario;
using Dominio.Interfaces.Repositorio.Usuario;
using Dominio.Interfaces.Servicos.Usuario;
using Dominio.Recurso;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Dominio.Servicos.Usuario
{
    public class ServicoUsuario : Notifiable, IServicoUsuario
    {
        private readonly IRepositorioUsuario _repositorio;
        private readonly IMapper _mapper;

        public ServicoUsuario() { }

        public ServicoUsuario(IRepositorioUsuario repositorio, IMapper mapper)
        {
            _mapper = mapper;
            _repositorio = repositorio;
        }

        public UsuarioResponse Selecionar(int id)
        {
            if (id == 0)
            {
                AddNotification("Request", Mensagens.DADOS_NAO_INFORMADOS);
                return null;
            }

            return _mapper.Map<UsuarioResponse>(_repositorio.ObterPorId(id));
        }

        public UsuarioResponse Adicionar(UsuarioRequest request)
        {
            if (request == null)
            {
                AddNotification("Request", Mensagens.DADOS_NAO_INFORMADOS);
                return null;
            }


            if(_repositorio.Existe(x => x.Email.ToUpper() == request.Email.ToUpper()))
                AddNotification("E-mail", Mensagens.JA_EXISTE_UM_X0_CADASTRADO_NO_SISTEMA.ToFormat("e-mail", request.Email));

            var entidade = new Entidades.Usuario.Usuario(request);
            AddNotifications(entidade);

            if (IsInvalid()) return null;
            
            return _mapper.Map<UsuarioResponse>(_repositorio.Adicionar(entidade));
        }

        public UsuarioResponse Alterar(UsuarioRequest request)
        {
            if (request == null)
            {
                AddNotification("Request", Mensagens.DADOS_NAO_INFORMADOS);
                return null;
            }

            var entidade = _repositorio.ObterPorId(request.Id);

            if (entidade == null)
            {
                AddNotification("Validation", Mensagens.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            entidade.Atualizar(request);

            AddNotifications(entidade);
            if (IsInvalid()) return null;

            var response = _repositorio.Editar(entidade);
            return _mapper.Map<UsuarioResponse>(entidade); //ou (UsuarioResponse)entidade;
        }

        public IEnumerable<UsuarioResponse> Listar() => _mapper.Map<IEnumerable<UsuarioResponse>>(_repositorio.Listar().ToList());
        public IEnumerable<UsuarioResponse> ListarAtivos() => _mapper.Map<IEnumerable<UsuarioResponse>>(_repositorio.Listar().Where(x => x.Status == true).ToList());
    }
}
