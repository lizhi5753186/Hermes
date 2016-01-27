using System.Configuration;

namespace Hermes.Engine.Internal.Configuration.ConfigurationSectionHandlers.Elements
{
    public class ExchangeConfigurationElement : 
        ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return this["name"] as string; }
            set { this["name"] = value; }
        }
    }
}