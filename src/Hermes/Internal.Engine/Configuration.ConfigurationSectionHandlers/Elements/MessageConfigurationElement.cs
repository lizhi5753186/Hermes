using System.Configuration;

namespace Hermes.Internal.Engine.Configuration.ConfigurationSectionHandlers.Elements
{
    internal class MessageConfigurationElement :
        ConfigurationElement
    {
        [ConfigurationProperty("type", IsRequired = true)]
        internal string Type
        {
            get { return this["type"] as string; }
            set { this["type"] = value; }
        }

        [ConfigurationProperty("exchange", IsRequired = false)]
        internal string Exchange
        {
            get { return this["exchange"] as string; }
            set { this["exchange"] = value; }
        }

        [ConfigurationProperty("host", IsRequired = false)]
        internal string Host
        {
            get { return this["host"] as string; }
            set { this["host"] = value; }
        }
    }
}