using System.Configuration;

namespace Hermes.Internal.Engine.Configuration.ConfigurationSectionHandlers.Elements
{
    internal class ExchangeConfigurationElement : 
        ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        internal string Name
        {
            get { return this["name"] as string; }
            set { this["name"] = value; }
        }
    }
}