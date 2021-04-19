using AutoMapper;
using Unity;

namespace Utilidade.AutoMapper
{
    public class Configuracao
    {
        public MapperConfiguration Configure(UnityContainer container)
        {
            var mapConfig = new MapperConfiguration(cfg => { cfg.AddProfile<Map>(); });
            IMapper map = mapConfig.CreateMapper();
            container.RegisterInstance(map);
            return mapConfig;
        }
    }
}
