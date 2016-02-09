using System.Configuration;
using Hermes.Internal.Engine.Configuration.ConfigurationSectionHandlers.Collections;

namespace Hermes.Internal.Engine.Configuration.ConfigurationSectionHandlers.Elements
{
    internal class HostConfigurationElement : 
        ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        internal string Name
        {
            get { return this["name"] as string; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("address", IsRequired = true)]
        internal string Address
        {
            get { return this["address"] as string; }
            set { this["address"] = value; }
        }

        [ConfigurationProperty("exchanges", IsRequired = false)]
        internal ExchangeCollection Exchanges
        {
            get { return this["exchanges"] as ExchangeCollection; }
            set { this["exchanges"] = value; }
        }
    }
}