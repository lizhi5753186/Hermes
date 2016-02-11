using System.Configuration;
using Hermes.Internal.Engine.Configuration.ConfigurationSectionHandlers.Collections;

namespace Hermes.Internal.Engine.Configuration.ConfigurationSectionHandlers.Elements
{
    internal class RabbitMqConfigurationElement :
        ConfigurationElement
    {
        [ConfigurationProperty("hosts", IsRequired = false)]
        internal HostCollection Hosts
        {
            get { return this["hosts"] as HostCollection; }
            set { this["hosts"] = value; }
        }
    }
}