using AutoMapper;
using Dominio.Argumentos.Usuario;
using Dominio.Entidades.Usuario;

namespace Infra.Persistencia.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Usuario, UsuarioResponse>();
        }
    }
}
