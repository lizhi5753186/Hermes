using System.Configuration;
using Hermes.Internal.Engine.Configuration.ConfigurationSectionHandlers.Elements;

namespace Hermes.Internal.Engine.Configuration.ConfigurationSectionHandlers
{
    internal class EngineConfigurationSection : 
        ConfigurationSection
    {
        [ConfigurationProperty("transport", IsRequired = false)]
        public TransportConfigurationElement Transport
        {
            get { return this["transport"] as TransportConfigurationElement; }
            set { this["transport"] = value; }
        }
    }
}
