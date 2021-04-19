using Dominio.Interfaces.Repositorio.Usuario;
using Infra.Persistencia.Repositorios.Base;
using System.Data.SqlClient;

namespace Infra.Persistencia.Repositorios.Usuario
{
    public class RepositorioUsuario : RepositorioBase<Dominio.Entidades.Usuario.Usuario, int>, IRepositorioUsuario
    {
        protected readonly Contexto _context;
        public RepositorioUsuario(Contexto context) : base(context)
        {
            _context = context;
        }
        public Dominio.Entidades.Usuario.Usuario Exemplo(Dominio.Entidades.Usuario.Usuario request)
        {
            var usuario = _context.Set<Dominio.Entidades.Usuario.Usuario>().SqlQuery("Select * from Usuario where UsuarioId = @id", new SqlParameter("@id", 1));
            return request;
        }
    }
}
