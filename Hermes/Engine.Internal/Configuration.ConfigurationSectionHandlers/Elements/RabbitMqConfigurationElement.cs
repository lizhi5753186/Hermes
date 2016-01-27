using System.Configuration;
using Hermes.Engine.Internal.Configuration.ConfigurationSectionHandlers.Collections;

namespace Hermes.Engine.Internal.Configuration.ConfigurationSectionHandlers.Elements
{
    internal class RabbitMqConfigurationElement :
        ConfigurationElement
    {
        [ConfigurationProperty("exchanges", IsRequired = false)]
        internal ExchangeCollection Exchanges
        {
            get { return this["exchanges"] as ExchangeCollection; }
            set { this["exchanges"] = value; }
        }

        [ConfigurationProperty("publishers", IsRequired = false)]
        internal PublisherCollection Publishers
        {
            get { return this["publishers"] as PublisherCollection; }
            set { this["publishers"] = value; }
        }
    }
}