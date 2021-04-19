using Dominio.Argumentos.Usuario;
using Dominio.Interfaces.Servicos.Base;
using System.Collections.Generic;

namespace Dominio.Interfaces.Servicos.Usuario
{
    public interface IServicoUsuario : IServicoBase<UsuarioRequest, UsuarioResponse>
    {
        UsuarioResponse Adicionar(UsuarioRequest request);
        UsuarioResponse Alterar(UsuarioRequest request);
        IEnumerable<UsuarioResponse> Listar();
        UsuarioResponse Selecionar(int id);
        IEnumerable<UsuarioResponse> ListarAtivos();
    }
}
