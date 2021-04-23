using Dominio.Argumentos.Usuario;
using Dominio.Entidades.Base;
using Dominio.Recurso;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

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

            new AddNotifications<Usuario>(this).IfNullOrEmpty(x => x.Nome, Mensagens.O_CAMPO_X0_INVALIDO.ToFormat("Nome"));
            new AddNotifications<Usuario>(this).IfNotEmail(x => x.Email, Mensagens.O_CAMPO_X0_INVALIDO.ToFormat("Email"));
            new AddNotifications<Usuario>(this).IfNullOrEmpty(x => x.Senha, Mensagens.O_CAMPO_X0_INVALIDO.ToFormat("Senha"));
        }

        public void Atualizar(UsuarioRequest request)
        {
            Nome = request.Nome;
            Email = request.Email;
            Senha = request.Senha;
            if(request.Status.HasValue) Status = request.Status.Value;

            new AddNotifications<Usuario>(this).IfNullOrEmpty(x => x.Nome, Mensagens.O_CAMPO_X0_INVALIDO.ToFormat("Nome"));
            new AddNotifications<Usuario>(this).IfNotEmail(x => x.Email, Mensagens.O_CAMPO_X0_INVALIDO.ToFormat("Email"));
            new AddNotifications<Usuario>(this).IfNullOrEmpty(x => x.Senha, Mensagens.O_CAMPO_X0_INVALIDO.ToFormat("Senha"));
        }
    }
}
