using Dominio.Interfaces.Repositorio.Base;

namespace Dominio.Interfaces.Repositorio.Usuario
{
    public interface IRepositorioUsuario : IRepositorioBase<Dominio.Entidades.Usuario.Usuario, int>
    {
        Dominio.Entidades.Usuario.Usuario Exemplo(Dominio.Entidades.Usuario.Usuario request);
    }
}
