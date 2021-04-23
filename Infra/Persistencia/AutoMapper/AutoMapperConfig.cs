using AutoMapper;

namespace Infra.Persistencia.AutoMapper
{
    public class AutoMapperConfig
    {
        public MapperConfiguration Configure() => new MapperConfiguration(cfg => { cfg.AddProfile<Mapper>(); });
    }
}
