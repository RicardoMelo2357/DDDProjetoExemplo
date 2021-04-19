using Dominio.Argumentos.Usuario;
using Dominio.Entidades.Base;
using prmToolkit.NotificationPattern;

namespace Dominio.Entidades.Usuario
{
    public class Usuario : EntidadeBase
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public Usuario() { }
        public Usuario(UsuarioRequest request)
        {
            Nome = request.Nome;
            Email = request.Email;
            Senha = request.Senha;

            new AddNotifications<Usuario>(this).IfNullOrEmpty(x => x.Nome);
            new AddNotifications<Usuario>(this).IfNullOrEmpty(x => x.Email);
            new AddNotifications<Usuario>(this).IfNullOrEmpty(x => x.Senha);
        }

        public void Atualizar(UsuarioRequest request)
        {
            Nome = request.Nome;
            Email = request.Email;
            Senha = request.Senha;

            new AddNotifications<Usuario>(this).IfNullOrEmpty(x => x.Nome);
            new AddNotifications<Usuario>(this).IfNullOrEmpty(x => x.Email);
            new AddNotifications<Usuario>(this).IfNullOrEmpty(x => x.Senha);
        }
    }
}
