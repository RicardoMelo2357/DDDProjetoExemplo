using AutoMapper;
using Dominio.Argumentos.Usuario;
using Dominio.Entidades.Usuario;

namespace IoC.AutoMapper
{
    public class Map : Profile
    {
        public Map()
        {
            CreateMap<Usuario, UsuarioResponse>();
        }
    }
}
