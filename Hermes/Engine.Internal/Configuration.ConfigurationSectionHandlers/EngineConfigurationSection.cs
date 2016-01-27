using System;
using System.Configuration;
using Hermes.Engine.Internal.Configuration.ConfigurationSectionHandlers.Elements;

namespace Hermes.Engine.Internal.Configuration.ConfigurationSectionHandlers
{
    public class EngineConfigurationSection : 
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
