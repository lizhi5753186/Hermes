using Hermes.Internal.Contracts;
using Hermes.Internal.Engine.Configuration.Parser;
using StructureMap;

namespace Hermes.Internal.Engine.StructureMap.Registries
{
    public class ConfigurationLoaderRegistry : 
        Registry
    {
        public ConfigurationLoaderRegistry()
        {
            For<IConfigurationLoader>()
                .Use<ConfigurationLoader>()
                .Singleton();
        }
    }
}
