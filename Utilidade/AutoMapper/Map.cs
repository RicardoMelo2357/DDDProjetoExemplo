using AutoMapper;
using Dominio.Argumentos.Usuario;
using Dominio.Entidades.Usuario;
using Unity;

namespace Utilidade.AutoMapper
{
    public class Map : Profile
    {
        public Map()
        {
            CreateMap<Usuario, UsuarioResponse>();
        }
    }
}
