using AutoMapper;
using StructureMap;
using StructureMap.Graph;

namespace Hermes.Internal.Engine.StructureMap.Registries
{
    public class MapperConfigurationRegistry : 
        Registry
    {
        public MapperConfigurationRegistry()
        {
            Scan(scanner =>
            {
                scanner.TheCallingAssembly();
                For<IConfiguration>().Use(new MapperConfiguration(x => { }));
            });
        }
    }
}
