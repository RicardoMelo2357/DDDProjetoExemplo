using Dominio.Argumentos.Base;

namespace Dominio.Argumentos.Usuario
{
    public class UsuarioResponse : ArgumentoBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public static explicit operator UsuarioResponse(Dominio.Entidades.Usuario.Usuario entidade)
        {
            return new UsuarioResponse()
            {
                Nome = entidade.Nome,
                Email = entidade.Email
            };
        }
    }
}
