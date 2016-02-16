using System.Configuration;
using Hermes.Internal.Contracts;
using Hermes.Internal.Engine.Configuration.ConfigurationSectionHandlers;

namespace Hermes.Internal.Engine.Configuration.Parser
{
    internal class ConfigurationLoader :
        IConfigurationLoader
    {
        private const string HermesConfigurationSectionName = "hermesConfiguration";
        private EngineConfiguration EngineConfiguration { get; set; }

        public EngineConfiguration Load()
        {
            // For now I want to force the a restart of the Engine to refresh the config settings... To enable this dynamically can cause serious 
            // issues with the operation of the Engine because queues might be added or removed and that could lead to data loss...
            if (EngineConfiguration == null)
            {
                EngineConfiguration = ConfigurationManager.GetSection(HermesConfigurationSectionName) as EngineConfiguration;
            }

            return EngineConfiguration;
        }
    }
}
