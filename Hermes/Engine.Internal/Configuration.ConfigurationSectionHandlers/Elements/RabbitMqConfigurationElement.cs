using System.Configuration;
using Hermes.Engine.Internal.Configuration.ConfigurationSectionHandlers.Collections;

namespace Hermes.Engine.Internal.Configuration.ConfigurationSectionHandlers.Elements
{
    public class RabbitMqConfigurationElement :
        ConfigurationElement
    {
        [ConfigurationProperty("exchanges", IsRequired = false)]
        public ExchangeCollection Exchanges
        {
            get { return this["exchanges"] as ExchangeCollection; }
            set { this["exchanges"] = value; }
        }

        [ConfigurationProperty("publishers", IsRequired = false)]
        public PublisherCollection Publishers
        {
            get { return this["publishers"] as PublisherCollection; }
            set { this["publishers"] = value; }
        }
    }
}