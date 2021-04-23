using Dominio.Interfaces.Repositorio.Base;
using System.Data.Entity.Infrastructure;

namespace Dominio.Interfaces.Repositorio.Usuario
{
    public interface IRepositorioUsuario : IRepositorioBase<Dominio.Entidades.Usuario.Usuario, int>
    {
        DbSqlQuery<Dominio.Entidades.Usuario.Usuario> Exemplo(Dominio.Entidades.Usuario.Usuario request);
        DbSqlQuery<Dominio.Entidades.Usuario.Usuario> Exemplo2(Dominio.Entidades.Usuario.Usuario request);
    }
}
