using System.Configuration;

namespace Hermes.Engine.Internal.Configuration.ConfigurationSectionHandlers.Elements
{
    public class MessageConfigurationElement :
        ConfigurationElement
    {
        [ConfigurationProperty("type", IsRequired = true)]
        public string Type
        {
            get { return this["type"] as string; }
            set { this["type"] = value; }
        }

        [ConfigurationProperty("exchange", IsRequired = false)]
        public string Exchange
        {
            get { return this["exchange"] as string; }
            set { this["exchange"] = value; }
        }
    }
}