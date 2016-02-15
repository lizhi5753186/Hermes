using System.Configuration;

namespace Hermes.Internal.Engine.Configuration.ConfigurationSectionHandlers.Elements
{
    internal class SubscriberMessageConcurrencyConfigurationElement :
        ConfigurationElement
    {
        public SubscriberMessageConcurrencyConfigurationElement()
        {
            Count = 5;
        }

        [ConfigurationProperty("count", IsRequired = false)]
        internal int Count
        {
            get { return (int)this["count"]; }
            set { this["count"] = value; }
        }
    }
}