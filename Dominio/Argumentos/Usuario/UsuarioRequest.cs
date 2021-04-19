using Dominio.Argumentos.Base;

namespace Dominio.Argumentos.Usuario
{
    public class UsuarioRequest : ArgumentoBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
