using System.Configuration;

namespace Hermes.Engine.Internal.Configuration.ConfigurationSectionHandlers.Elements
{
    internal class TransportConfigurationElement :
        ConfigurationElement
    {
        [ConfigurationProperty("rabbitMq", IsRequired = false)]
        internal RabbitMqConfigurationElement RabbitMq
        {
            get { return this["rabbitMq"] as RabbitMqConfigurationElement; }
            set { this["rabbitMq"] = value; }
        }

        [ConfigurationProperty("msmq", IsRequired = false)]
        internal MsmqConfigurationElement Msmq
        {
            get { return this["msmq"] as MsmqConfigurationElement; }
            set { this["msmq"] = value; }
        }
    }
}