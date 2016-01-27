using System.Configuration;

namespace Hermes.Engine.Internal.Configuration.ConfigurationSectionHandlers.Elements
{
    public class TransportConfigurationElement :
        ConfigurationElement
    {
        [ConfigurationProperty("rabbitMq", IsRequired = false)]
        public RabbitMqConfigurationElement RabbitMq
        {
            get { return this["rabbitMq"] as RabbitMqConfigurationElement; }
            set { this["rabbitMq"] = value; }
        }

        [ConfigurationProperty("msmq", IsRequired = false)]
        public MsmqConfigurationElement Msmq
        {
            get { return this["msmq"] as MsmqConfigurationElement; }
            set { this["msmq"] = value; }
        }
    }
}